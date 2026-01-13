using System.Data;
using Dapper;
using Transac.Domain.Entities;
using Transac.Domain.Interfaces;

namespace Transact.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IDbConnection _connection;
    private IDbTransaction? _transaction;

    public CustomerRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public void SetTransaction(IDbTransaction transaction)
    {
        _transaction = transaction;
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        const string sql = @"
            SELECT Id, FirstName, LastName, Email, PhoneNumber, CustomerType, DateCreated, DateModified, IsActive
            FROM Customers
            WHERE Id = @Id";

        return await _connection.QueryFirstOrDefaultAsync<Customer>(sql, new { Id = id }, _transaction);
    }

    public async Task<Customer?> GetByAccountNumberAsync(string accountNumber)
    {
        const string sql = @"
            SELECT c.Id, c.FirstName, c.LastName, c.Email, c.PhoneNumber, c.CustomerType, c.DateCreated, c.DateModified, c.IsActive
            FROM Customers c
            INNER JOIN Accounts a ON c.Id = a.CustomerId
            WHERE a.AccountNumber = @AccountNumber";

        return await _connection.QueryFirstOrDefaultAsync<Customer>(sql, new { AccountNumber = accountNumber }, _transaction);
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        const string sql = @"
            SELECT Id, FirstName, LastName, Email, PhoneNumber, CustomerType, DateCreated, DateModified, IsActive
            FROM Customers
            WHERE IsActive = 1";

        return await _connection.QueryAsync<Customer>(sql, transaction: _transaction);
    }

    public async Task<Guid> AddAsync(Customer entity)
    {
        const string sql = @"
            INSERT INTO Customers (Id, FirstName, LastName, Email, PhoneNumber, CustomerType, DateCreated, IsActive)
            VALUES (@Id, @FirstName, @LastName, @Email, @PhoneNumber, @CustomerType, @DateCreated, @IsActive)";

        entity.Id = Guid.NewGuid();
        entity.DateCreated = DateTime.UtcNow;
        
        await _connection.ExecuteAsync(sql, entity, _transaction);
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(Customer entity)
    {
        const string sql = @"
            UPDATE Customers
            SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber,
                CustomerType = @CustomerType, DateModified = @DateModified, IsActive = @IsActive
            WHERE Id = @Id";

        entity.DateModified = DateTime.UtcNow;
        var affected = await _connection.ExecuteAsync(sql, entity, _transaction);
        return affected > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        const string sql = "UPDATE Customers SET IsActive = 0, DateModified = @DateModified WHERE Id = @Id";
        var affected = await _connection.ExecuteAsync(sql, new { Id = id, DateModified = DateTime.UtcNow }, _transaction);
        return affected > 0;
    }
}
