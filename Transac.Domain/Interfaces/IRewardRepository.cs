using Transac.Domain.Entities;
using Transac.Domain.Enums;

namespace Transac.Domain.Interfaces;

public interface IRewardRepository : IRepository<Reward>
{
    Task<bool> HasReceivedRewardForMonthAsync(Guid customerId, RewardType rewardType, int month, int year);
    Task<Reward?> GetPendingFreeAirtimeRewardAsync(Guid customerId);
}
