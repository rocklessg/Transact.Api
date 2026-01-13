using Transac.Domain.Entities;

namespace Transac.Domain.Interfaces;

public interface ITransactionRepository : IRepository<Transaction>
{
    Task<IEnumerable<Transaction>> GetByAccountNumberAsync(string accountNumber);
    Task<int> GetTransactionCountForMonthAsync(Guid customerId, int month, int year);
}
