using Transac.Domain.Entities;
using Transact.Application.DTOs.Responses;

namespace Transact.Application.Interfaces;

public interface ILoyaltyService
{
    Task<(int pointsEarned, RewardInfo? reward)> ProcessLoyaltyAsync(Customer customer, Transaction transaction);
}
