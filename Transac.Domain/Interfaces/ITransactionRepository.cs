using Transac.Domain.Entities;

namespace Transac.Domain.Interfaces;

public interface ITransactionRepository : IRepository<Transaction, Guid>
{
    Task<IEnumerable<Transaction>> GetByAccountNumberAsync(string accountNumber);
    Task<int> GetTransactionCountForMonthAsync(long customerId, int month, int year);
}
