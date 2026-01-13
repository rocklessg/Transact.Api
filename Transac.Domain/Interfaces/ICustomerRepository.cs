using Transac.Domain.Entities;

namespace Transac.Domain.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer?> GetByAccountNumberAsync(string accountNumber);
}
