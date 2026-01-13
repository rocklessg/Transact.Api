using Transac.Domain.Entities;

namespace Transac.Domain.Interfaces;

public interface ILoyaltyPointRepository : IRepository<LoyaltyPoint>
{
    Task<int> GetTotalPointsForMonthAsync(Guid customerId, int month, int year);
    Task<int> GetPointTransactionCountForMonthAsync(Guid customerId, int month, int year);
}
