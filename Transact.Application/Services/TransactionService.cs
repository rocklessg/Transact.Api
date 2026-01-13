using Transac.Domain.Entities;
using Transac.Domain.Enums;
using Transac.Domain.Interfaces;
using Transact.Application.DTOs.Requests;
using Transact.Application.DTOs.Responses;
using Transact.Application.Interfaces;
using Transact.Application.Validators;

namespace Transact.Application.Services;

public class TransactionService : ITransactionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoyaltyService _loyaltyService;
    private readonly IValidator<TransferRequest> _transferValidator;
    private readonly IValidator<BuyAirtimeRequest> _airtimeValidator;

    public TransactionService(
        IUnitOfWork unitOfWork,
        ILoyaltyService loyaltyService,
        IValidator<TransferRequest> transferValidator,
        IValidator<BuyAirtimeRequest> airtimeValidator)
    {
        _unitOfWork = unitOfWork;
        _loyaltyService = loyaltyService;
        _transferValidator = transferValidator;
        _airtimeValidator = airtimeValidator;
    }

    public async Task<ApiResponse<TransferResponse>> ProcessTransferAsync(TransferRequest request)
    {
        var (isValid, errors) = _transferValidator.Validate(request);
        if (!isValid)
        {
            return ApiResponse<TransferResponse>.FailureResponse("Validation failed", errors);
        }

        var sourceAccount = await _unitOfWork.Accounts.GetByAccountNumberAsync(request.SourceAccount);
        if (sourceAccount == null)
        {
            return ApiResponse<TransferResponse>.FailureResponse("Source account not found");
        }

        var destinationAccount = await _unitOfWork.Accounts.GetByAccountNumberAsync(request.DestinationAccount);
        if (destinationAccount == null)
        {
            return ApiResponse<TransferResponse>.FailureResponse("Destination account not found");
        }

        if (sourceAccount.Balance < request.Amount)
        {
            return ApiResponse<TransferResponse>.FailureResponse("Insufficient balance");
        }

        var customer = await _unitOfWork.Customers.GetByIdAsync(sourceAccount.CustomerId);
        if (customer == null)
        {
            return ApiResponse<TransferResponse>.FailureResponse("Customer not found");
        }

        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                SourceAccountId = sourceAccount.Id,
                DestinationAccountId = destinationAccount.Id,
                SourceAccountNumber = sourceAccount.AccountNumber,
                DestinationAccountNumber = destinationAccount.AccountNumber,
                Amount = request.Amount,
                TransactionType = TransactionType.Transfer,
                Reference = GenerateTransactionReference(),
                Narration = $"Transfer to {destinationAccount.AccountNumber}",
                TransactionDate = DateTime.UtcNow,
                IsSuccessful = true
            };

            await _unitOfWork.Transactions.AddAsync(transaction);

            var (pointsEarned, reward) = await _loyaltyService.ProcessLoyaltyAsync(customer, transaction);

            await _unitOfWork.CommitAsync();

            var response = new TransferResponse
            {
                TransactionReference = transaction.Reference,
                SourceAccount = request.SourceAccount,
                DestinationAccount = request.DestinationAccount,
                Amount = request.Amount,
                TransactionDate = transaction.TransactionDate,
                PointsEarned = pointsEarned,
                Reward = reward
            };

            return ApiResponse<TransferResponse>.SuccessResponse(response, "Transfer completed successfully");
        }
        catch
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task<ApiResponse<AirtimeResponse>> ProcessAirtimePurchaseAsync(BuyAirtimeRequest request)
    {
        var (isValid, errors) = _airtimeValidator.Validate(request);
        if (!isValid)
        {
            return ApiResponse<AirtimeResponse>.FailureResponse("Validation failed", errors);
        }

        var sourceAccount = await _unitOfWork.Accounts.GetByAccountNumberAsync(request.SourceAccount);
        if (sourceAccount == null)
        {
            return ApiResponse<AirtimeResponse>.FailureResponse("Source account not found");
        }

        if (sourceAccount.Balance < request.Amount)
        {
            return ApiResponse<AirtimeResponse>.FailureResponse("Insufficient balance");
        }

        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                SourceAccountId = sourceAccount.Id,
                SourceAccountNumber = sourceAccount.AccountNumber,
                Amount = request.Amount,
                TransactionType = TransactionType.Airtime,
                NetworkProvider = request.NetworkProvider,
                PhoneNumber = request.PhoneNumber,
                Reference = GenerateTransactionReference(),
                Narration = $"Airtime purchase - {request.NetworkProvider} - {request.PhoneNumber}",
                TransactionDate = DateTime.UtcNow,
                IsSuccessful = true
            };

            await _unitOfWork.Transactions.AddAsync(transaction);

            await _unitOfWork.CommitAsync();

            var response = new AirtimeResponse
            {
                TransactionReference = transaction.Reference,
                SourceAccount = request.SourceAccount,
                NetworkProvider = request.NetworkProvider,
                PhoneNumber = request.PhoneNumber,
                Amount = request.Amount,
                TransactionDate = transaction.TransactionDate
            };

            return ApiResponse<AirtimeResponse>.SuccessResponse(response, "Airtime purchase completed successfully");
        }
        catch
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task<ApiResponse<TransactionHistoryResponse>> GetTransactionHistoryAsync(string accountNumber)
    {
        if (string.IsNullOrWhiteSpace(accountNumber))
        {
            return ApiResponse<TransactionHistoryResponse>.FailureResponse("Account number is required");
        }

        var account = await _unitOfWork.Accounts.GetByAccountNumberAsync(accountNumber);
        if (account == null)
        {
            return ApiResponse<TransactionHistoryResponse>.FailureResponse("Account not found");
        }

        var transactions = await _unitOfWork.Transactions.GetByAccountNumberAsync(accountNumber);

        var response = new TransactionHistoryResponse
        {
            AccountNumber = accountNumber,
            Transactions = transactions.Select(t => new TransactionDetail
            {
                TransactionReference = t.Reference,
                TransactionType = t.TransactionType.ToString(),
                Amount = t.Amount,
                DestinationAccount = t.DestinationAccountNumber,
                NetworkProvider = t.NetworkProvider,
                PhoneNumber = t.PhoneNumber,
                Narration = t.Narration,
                TransactionDate = t.TransactionDate,
                IsSuccessful = t.IsSuccessful
            }).ToList()
        };

        return ApiResponse<TransactionHistoryResponse>.SuccessResponse(response);
    }

    private static string GenerateTransactionReference()
    {
        return $"TXN{DateTime.UtcNow:yyyyMMddHHmmss}{Guid.NewGuid().ToString("N")[..8].ToUpper()}";
    }
}
