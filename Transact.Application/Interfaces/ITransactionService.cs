using Transact.Application.DTOs.Requests;
using Transact.Application.DTOs.Responses;

namespace Transact.Application.Interfaces;

public interface ITransactionService
{
    Task<ApiResponse<TransferResponse>> ProcessTransferAsync(TransferRequest request);
    Task<ApiResponse<AirtimeResponse>> ProcessAirtimePurchaseAsync(BuyAirtimeRequest request);
    Task<ApiResponse<TransactionHistoryResponse>> GetTransactionHistoryAsync(string accountNumber);
}
