using Transac.Domain.Entities;
using Transac.Domain.Enums;

namespace Transac.Domain.Interfaces;

public interface IRewardRepository : IRepository<Reward, Guid>
{
    Task<bool> HasReceivedRewardForMonthAsync(long customerId, RewardType rewardType, int month, int year);
    Task<Reward?> GetPendingFreeAirtimeRewardAsync(long customerId);
}
