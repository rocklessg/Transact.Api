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

    public async Task<Account?> GetByIdAsync(Guid id)
    {
        const string sql = @"
            SELECT Id, CustomerId, AccountNumber, Balance, DateCreated, DateModified, IsActive
            FROM Accounts
            WHERE Id = @Id";

        return await _connection.QueryFirstOrDefaultAsync<Account>(sql, new { Id = id }, _transaction);
    }

    public async Task<Account?> GetByAccountNumberAsync(string accountNumber)
    {
        const string sql = @"
            SELECT Id, CustomerId, AccountNumber, Balance, DateCreated, DateModified, IsActive
            FROM Accounts
            WHERE AccountNumber = @AccountNumber AND IsActive = 1";

        return await _connection.QueryFirstOrDefaultAsync<Account>(sql, new { AccountNumber = accountNumber }, _transaction);
    }

    public async Task<IEnumerable<Account>> GetByCustomerIdAsync(Guid customerId)
    {
        const string sql = @"
            SELECT Id, CustomerId, AccountNumber, Balance, DateCreated, DateModified, IsActive
            FROM Accounts
            WHERE CustomerId = @CustomerId AND IsActive = 1";

        return await _connection.QueryAsync<Account>(sql, new { CustomerId = customerId }, _transaction);
    }

    public async Task<IEnumerable<Account>> GetAllAsync()
    {
        const string sql = @"
            SELECT Id, CustomerId, AccountNumber, Balance, DateCreated, DateModified, IsActive
            FROM Accounts
            WHERE IsActive = 1";

        return await _connection.QueryAsync<Account>(sql, transaction: _transaction);
    }

    public async Task<Guid> AddAsync(Account entity)
    {
        const string sql = @"
            INSERT INTO Accounts (Id, CustomerId, AccountNumber, Balance, DateCreated, IsActive)
            VALUES (@Id, @CustomerId, @AccountNumber, @Balance, @DateCreated, @IsActive)";

        entity.Id = Guid.NewGuid();
        entity.DateCreated = DateTime.UtcNow;

        await _connection.ExecuteAsync(sql, entity, _transaction);
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(Account entity)
    {
        const string sql = @"
            UPDATE Accounts
            SET CustomerId = @CustomerId, AccountNumber = @AccountNumber, Balance = @Balance,
                DateModified = @DateModified, IsActive = @IsActive
            WHERE Id = @Id";

        entity.DateModified = DateTime.UtcNow;
        var affected = await _connection.ExecuteAsync(sql, entity, _transaction);
        return affected > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        const string sql = "UPDATE Accounts SET IsActive = 0, DateModified = @DateModified WHERE Id = @Id";
        var affected = await _connection.ExecuteAsync(sql, new { Id = id, DateModified = DateTime.UtcNow }, _transaction);
        return affected > 0;
    }
}
