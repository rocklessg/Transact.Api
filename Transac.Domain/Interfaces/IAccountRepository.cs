using Transac.Domain.Entities;

namespace Transac.Domain.Interfaces;

public interface IAccountRepository : IRepository<Account>
{
    Task<Account?> GetByAccountNumberAsync(string accountNumber);
    Task<IEnumerable<Account>> GetByCustomerIdAsync(Guid customerId);
}
