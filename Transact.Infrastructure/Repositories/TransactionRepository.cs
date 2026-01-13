using System.Data;
using Dapper;
using Transac.Domain.Entities;
using Transac.Domain.Enums;
using Transac.Domain.Interfaces;

namespace Transact.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IDbConnection _connection;
    private IDbTransaction? _transaction;

    public TransactionRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public void SetTransaction(IDbTransaction transaction)
    {
        _transaction = transaction;
    }

    public async Task<Transaction?> GetByIdAsync(Guid id)
    {
        const string sql = @"
            SELECT Id, SourceAccountId, DestinationAccountId, SourceAccountNumber, DestinationAccountNumber,
                   Amount, TransactionType, NetworkProvider, PhoneNumber, Reference, Narration, TransactionDate, IsSuccessful
            FROM Transactions
            WHERE Id = @Id";

        return await _connection.QueryFirstOrDefaultAsync<Transaction>(sql, new { Id = id }, _transaction);
    }

    public async Task<IEnumerable<Transaction>> GetByAccountNumberAsync(string accountNumber)
    {
        const string sql = @"
            SELECT Id, SourceAccountId, DestinationAccountId, SourceAccountNumber, DestinationAccountNumber,
                   Amount, TransactionType, NetworkProvider, PhoneNumber, Reference, Narration, TransactionDate, IsSuccessful
            FROM Transactions
            WHERE SourceAccountNumber = @AccountNumber OR DestinationAccountNumber = @AccountNumber
            ORDER BY TransactionDate DESC";

        return await _connection.QueryAsync<Transaction>(sql, new { AccountNumber = accountNumber }, _transaction);
    }

    public async Task<int> GetTransactionCountForMonthAsync(Guid customerId, int month, int year)
    {
        const string sql = @"
            SELECT COUNT(*)
            FROM Transactions t
            INNER JOIN Accounts a ON t.SourceAccountId = a.Id
            WHERE a.CustomerId = @CustomerId
              AND t.TransactionType = @TransactionType
              AND MONTH(t.TransactionDate) = @Month
              AND YEAR(t.TransactionDate) = @Year
              AND t.IsSuccessful = 1";

        return await _connection.ExecuteScalarAsync<int>(sql, new 
        { 
            CustomerId = customerId, 
            TransactionType = (int)TransactionType.Transfer,
            Month = month, 
            Year = year 
        }, _transaction);
    }

    public async Task<IEnumerable<Transaction>> GetAllAsync()
    {
        const string sql = @"
            SELECT Id, SourceAccountId, DestinationAccountId, SourceAccountNumber, DestinationAccountNumber,
                   Amount, TransactionType, NetworkProvider, PhoneNumber, Reference, Narration, TransactionDate, IsSuccessful
            FROM Transactions
            ORDER BY TransactionDate DESC";

        return await _connection.QueryAsync<Transaction>(sql, transaction: _transaction);
    }

    public async Task<Guid> AddAsync(Transaction entity)
    {
        const string sql = @"
            INSERT INTO Transactions (Id, SourceAccountId, DestinationAccountId, SourceAccountNumber, DestinationAccountNumber,
                                      Amount, TransactionType, NetworkProvider, PhoneNumber, Reference, Narration, TransactionDate, IsSuccessful)
            VALUES (@Id, @SourceAccountId, @DestinationAccountId, @SourceAccountNumber, @DestinationAccountNumber,
                    @Amount, @TransactionType, @NetworkProvider, @PhoneNumber, @Reference, @Narration, @TransactionDate, @IsSuccessful)";

        await _connection.ExecuteAsync(sql, entity, _transaction);
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(Transaction entity)
    {
        const string sql = @"
            UPDATE Transactions
            SET SourceAccountId = @SourceAccountId, DestinationAccountId = @DestinationAccountId,
                SourceAccountNumber = @SourceAccountNumber, DestinationAccountNumber = @DestinationAccountNumber,
                Amount = @Amount, TransactionType = @TransactionType, NetworkProvider = @NetworkProvider,
                PhoneNumber = @PhoneNumber, Reference = @Reference, Narration = @Narration, IsSuccessful = @IsSuccessful
            WHERE Id = @Id";

        var affected = await _connection.ExecuteAsync(sql, entity, _transaction);
        return affected > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        const string sql = "DELETE FROM Transactions WHERE Id = @Id";
        var affected = await _connection.ExecuteAsync(sql, new { Id = id }, _transaction);
        return affected > 0;
    }
}
