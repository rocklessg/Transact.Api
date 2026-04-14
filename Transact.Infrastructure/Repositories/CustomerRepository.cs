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

    public async Task<Customer?> GetByIdAsync(long id)
    {
        const string sql = @"
            SELECT CustomerId, CustomerName, CustomerType, DateCreated
            FROM CustomerData
            WHERE CustomerId = @CustomerId";

        return await _connection.QueryFirstOrDefaultAsync<Customer>(sql, new { CustomerId = id }, _transaction);
    }

    public async Task<Customer?> GetByAccountNumberAsync(string accountNumber)
    {
        const string sql = @"
            SELECT c.CustomerId, c.CustomerName, c.CustomerType, c.DateCreated
            FROM CustomerData c
            INNER JOIN AccountData a ON c.CustomerId = a.CustomerId
            WHERE a.AccountNumber = @AccountNumber";

        return await _connection.QueryFirstOrDefaultAsync<Customer>(sql, new { AccountNumber = accountNumber }, _transaction);
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        const string sql = @"
            SELECT CustomerId, CustomerName, CustomerType, DateCreated
            FROM CustomerData";

        return await _connection.QueryAsync<Customer>(sql, transaction: _transaction);
    }

    public async Task<long> AddAsync(Customer entity)
    {
        const string sql = @"
            INSERT INTO CustomerData (CustomerId, CustomerName, CustomerType, DateCreated)
            VALUES (@CustomerId, @CustomerName, @CustomerType, @DateCreated)";

        await _connection.ExecuteAsync(sql, entity, _transaction);
        return entity.CustomerId;
    }

    public async Task<bool> UpdateAsync(Customer entity)
    {
        const string sql = @"
            UPDATE CustomerData
            SET CustomerName = @CustomerName, CustomerType = @CustomerType
            WHERE CustomerId = @CustomerId";

        var affected = await _connection.ExecuteAsync(sql, entity, _transaction);
        return affected > 0;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        const string sql = "DELETE FROM CustomerData WHERE CustomerId = @CustomerId";
        var affected = await _connection.ExecuteAsync(sql, new { CustomerId = id }, _transaction);
        return affected > 0;
    }
}
