using Transac.Domain.Entities;

namespace Transac.Domain.Interfaces;

public interface ILoyaltyPointRepository : IRepository<LoyaltyPoint, Guid>
{
    Task<int> GetTotalPointsForMonthAsync(long customerId, int month, int year);
    Task<int> GetPointTransactionCountForMonthAsync(long customerId, int month, int year);
}
