using Transac.Domain.Entities;

namespace Transac.Domain.Interfaces;

public interface ICustomerRepository : IRepository<Customer, long>
{
    Task<Customer?> GetByAccountNumberAsync(string accountNumber);
}
