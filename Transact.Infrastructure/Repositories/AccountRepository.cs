using System.Data;
using Dapper;
using Transac.Domain.Entities;
using Transac.Domain.Interfaces;

namespace Transact.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IDbConnection _connection;
    private IDbTransaction? _transaction;

    public AccountRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public void SetTransaction(IDbTransaction transaction)
    {
        _transaction = transaction;
    }

    public async Task<Account?> GetByIdAsync(int id)
    {
        const string sql = @"
            SELECT AccountId, AccountNumber, CustomerId, AccountBalance, AccountOpenDate
            FROM AccountData
            WHERE AccountId = @AccountId";

        return await _connection.QueryFirstOrDefaultAsync<Account>(sql, new { AccountId = id }, _transaction);
    }

    public async Task<Account?> GetByAccountNumberAsync(string accountNumber)
    {
        const string sql = @"
            SELECT AccountId, AccountNumber, CustomerId, AccountBalance, AccountOpenDate
            FROM AccountData
            WHERE AccountNumber = @AccountNumber";

        return await _connection.QueryFirstOrDefaultAsync<Account>(sql, new { AccountNumber = accountNumber }, _transaction);
    }

    public async Task<IEnumerable<Account>> GetByCustomerIdAsync(long customerId)
    {
        const string sql = @"
            SELECT AccountId, AccountNumber, CustomerId, AccountBalance, AccountOpenDate
            FROM AccountData
            WHERE CustomerId = @CustomerId";

        return await _connection.QueryAsync<Account>(sql, new { CustomerId = customerId }, _transaction);
    }

    public async Task<IEnumerable<Account>> GetAllAsync()
    {
        const string sql = @"
            SELECT AccountId, AccountNumber, CustomerId, AccountBalance, AccountOpenDate
            FROM AccountData";

        return await _connection.QueryAsync<Account>(sql, transaction: _transaction);
    }

    public async Task<int> AddAsync(Account entity)
    {
        const string sql = @"
            INSERT INTO AccountData (AccountId, AccountNumber, CustomerId, AccountBalance, AccountOpenDate)
            VALUES (@AccountId, @AccountNumber, @CustomerId, @AccountBalance, @AccountOpenDate)";

        await _connection.ExecuteAsync(sql, entity, _transaction);
        return entity.AccountId;
    }

    public async Task<bool> UpdateAsync(Account entity)
    {
        const string sql = @"
            UPDATE AccountData
            SET AccountBalance = @AccountBalance
            WHERE AccountId = @AccountId";

        var affected = await _connection.ExecuteAsync(sql, entity, _transaction);
        return affected > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        const string sql = "DELETE FROM AccountData WHERE AccountId = @AccountId";
        var affected = await _connection.ExecuteAsync(sql, new { AccountId = id }, _transaction);
        return affected > 0;
    }
}
