using Transac.Domain.Constants;
using Transac.Domain.Entities;
using Transac.Domain.Enums;
using Transac.Domain.Interfaces;
using Transact.Application.DTOs.Responses;
using Transact.Application.Interfaces;

namespace Transact.Application.Services;

public class LoyaltyService : ILoyaltyService
{
    private readonly IUnitOfWork _unitOfWork;

    public LoyaltyService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<(int pointsEarned, RewardInfo? reward)> ProcessLoyaltyAsync(Customer customer, Transaction transaction)
    {
        if (transaction.TransactionType == TransactionType.Airtime)
        {
            return (0, null);
        }

        int basePoints = CalculateBasePoints(customer.CustomerType, transaction.Amount);
        
        if (basePoints == 0)
        {
            return (0, null);
        }

        int finalPoints = await ApplyTenureBonusAsync(customer, basePoints);

        await SaveLoyaltyPointsAsync(customer.Id, transaction.Id, finalPoints);

        var reward = await ProcessRewardsAsync(customer, transaction);

        return (finalPoints, reward);
    }

    private static int CalculateBasePoints(CustomerType customerType, decimal amount)
    {
        return customerType switch
        {
            CustomerType.Business when amount > LoyaltyConstants.BusinessMinTransactionAmount 
                => LoyaltyConstants.BusinessPointsPerTransaction,
            CustomerType.Retail when amount > LoyaltyConstants.RetailMinTransactionAmount 
                => LoyaltyConstants.RetailPointsPerTransaction,
            _ => 0
        };
    }

    private async Task<int> ApplyTenureBonusAsync(Customer customer, int basePoints)
    {
        int tenureYears = customer.GetTenureInYears();
        
        if (tenureYears <= LoyaltyConstants.TenureYearsForDoublePoints)
        {
            return basePoints;
        }

        int currentMonth = DateTime.UtcNow.Month;
        int currentYear = DateTime.UtcNow.Year;

        int pointTransactionCount = await _unitOfWork.LoyaltyPoints
            .GetPointTransactionCountForMonthAsync(customer.Id, currentMonth, currentYear);

        if (pointTransactionCount < LoyaltyConstants.MaxDoublePointsTransactionsPerMonth)
        {
            return basePoints * 2;
        }

        return basePoints;
    }

    private async Task SaveLoyaltyPointsAsync(Guid customerId, Guid transactionId, int points)
    {
        var loyaltyPoint = new LoyaltyPoint
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            TransactionId = transactionId,
            Points = points,
            EarnedDate = DateTime.UtcNow,
            Month = DateTime.UtcNow.Month,
            Year = DateTime.UtcNow.Year
        };

        await _unitOfWork.LoyaltyPoints.AddAsync(loyaltyPoint);
    }

    private async Task<RewardInfo?> ProcessRewardsAsync(Customer customer, Transaction transaction)
    {
        int currentMonth = DateTime.UtcNow.Month;
        int currentYear = DateTime.UtcNow.Year;

        return customer.CustomerType switch
        {
            CustomerType.Business => await ProcessBusinessRewardAsync(customer, transaction, currentMonth, currentYear),
            CustomerType.Retail => await ProcessRetailRewardAsync(customer, transaction, currentMonth, currentYear),
            _ => null
        };
    }

    private async Task<RewardInfo?> ProcessBusinessRewardAsync(Customer customer, Transaction transaction, int month, int year)
    {
        bool alreadyReceivedCashback = await _unitOfWork.Rewards
            .HasReceivedRewardForMonthAsync(customer.Id, RewardType.Cashback, month, year);

        if (alreadyReceivedCashback)
        {
            return null;
        }

        int totalPoints = await _unitOfWork.LoyaltyPoints
            .GetTotalPointsForMonthAsync(customer.Id, month, year);

        if (totalPoints >= LoyaltyConstants.BusinessPointsThresholdForCashback)
        {
            var reward = new Reward
            {
                Id = Guid.NewGuid(),
                CustomerId = customer.Id,
                TransactionId = transaction.Id,
                RewardType = RewardType.Cashback,
                Amount = LoyaltyConstants.BusinessCashbackAmount,
                AwardedDate = DateTime.UtcNow,
                Month = month,
                Year = year,
                IsProcessed = true
            };

            await _unitOfWork.Rewards.AddAsync(reward);

            return new RewardInfo
            {
                RewardType = "Cashback",
                Amount = LoyaltyConstants.BusinessCashbackAmount,
                Message = $"Congratulations! You have earned a cashback of {LoyaltyConstants.BusinessCashbackAmount:N0} for reaching {LoyaltyConstants.BusinessPointsThresholdForCashback} loyalty points this month."
            };
        }

        return null;
    }

    private async Task<RewardInfo?> ProcessRetailRewardAsync(Customer customer, Transaction transaction, int month, int year)
    {
        var pendingReward = await _unitOfWork.Rewards.GetPendingFreeAirtimeRewardAsync(customer.Id);
        
        if (pendingReward != null)
        {
            pendingReward.TransactionId = transaction.Id;
            pendingReward.IsProcessed = true;
            await _unitOfWork.Rewards.UpdateAsync(pendingReward);

            return new RewardInfo
            {
                RewardType = "FreeAirtime",
                Amount = pendingReward.Amount,
                Message = $"Your free airtime reward of {pendingReward.Amount:N0} has been processed!"
            };
        }

        bool alreadyQualified = await _unitOfWork.Rewards
            .HasReceivedRewardForMonthAsync(customer.Id, RewardType.FreeAirtime, month, year);

        if (alreadyQualified)
        {
            return null;
        }

        int transactionCount = await _unitOfWork.Transactions
            .GetTransactionCountForMonthAsync(customer.Id, month, year);

        if (transactionCount >= LoyaltyConstants.RetailTransactionsForFreeAirtime)
        {
            var reward = new Reward
            {
                Id = Guid.NewGuid(),
                CustomerId = customer.Id,
                TransactionId = null,
                RewardType = RewardType.FreeAirtime,
                Amount = LoyaltyConstants.RetailFreeAirtimeAmount,
                AwardedDate = DateTime.UtcNow,
                Month = month,
                Year = year,
                IsProcessed = false
            };

            await _unitOfWork.Rewards.AddAsync(reward);

            return new RewardInfo
            {
                RewardType = "FreeAirtime",
                Amount = LoyaltyConstants.RetailFreeAirtimeAmount,
                Message = $"Congratulations! You have qualified for free airtime of {LoyaltyConstants.RetailFreeAirtimeAmount:N0}. It will be automatically applied on your next transaction."
            };
        }

        return null;
    }
}
