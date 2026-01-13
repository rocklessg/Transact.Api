using System.Data;
using Dapper;
using Transac.Domain.Entities;
using Transac.Domain.Interfaces;

namespace Transact.Infrastructure.Repositories;

public class LoyaltyPointRepository : ILoyaltyPointRepository
{
    private readonly IDbConnection _connection;
    private IDbTransaction? _transaction;

    public LoyaltyPointRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public void SetTransaction(IDbTransaction transaction)
    {
        _transaction = transaction;
    }

    public async Task<LoyaltyPoint?> GetByIdAsync(Guid id)
    {
        const string sql = @"
            SELECT Id, CustomerId, TransactionId, Points, EarnedDate, Month, Year
            FROM LoyaltyPoints
            WHERE Id = @Id";

        return await _connection.QueryFirstOrDefaultAsync<LoyaltyPoint>(sql, new { Id = id }, _transaction);
    }

    public async Task<int> GetTotalPointsForMonthAsync(Guid customerId, int month, int year)
    {
        const string sql = @"
            SELECT ISNULL(SUM(Points), 0)
            FROM LoyaltyPoints
            WHERE CustomerId = @CustomerId AND Month = @Month AND Year = @Year";

        return await _connection.ExecuteScalarAsync<int>(sql, new { CustomerId = customerId, Month = month, Year = year }, _transaction);
    }

    public async Task<int> GetPointTransactionCountForMonthAsync(Guid customerId, int month, int year)
    {
        const string sql = @"
            SELECT COUNT(*)
            FROM LoyaltyPoints
            WHERE CustomerId = @CustomerId AND Month = @Month AND Year = @Year";

        return await _connection.ExecuteScalarAsync<int>(sql, new { CustomerId = customerId, Month = month, Year = year }, _transaction);
    }

    public async Task<IEnumerable<LoyaltyPoint>> GetAllAsync()
    {
        const string sql = @"
            SELECT Id, CustomerId, TransactionId, Points, EarnedDate, Month, Year
            FROM LoyaltyPoints";

        return await _connection.QueryAsync<LoyaltyPoint>(sql, transaction: _transaction);
    }

    public async Task<Guid> AddAsync(LoyaltyPoint entity)
    {
        const string sql = @"
            INSERT INTO LoyaltyPoints (Id, CustomerId, TransactionId, Points, EarnedDate, Month, Year)
            VALUES (@Id, @CustomerId, @TransactionId, @Points, @EarnedDate, @Month, @Year)";

        await _connection.ExecuteAsync(sql, entity, _transaction);
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(LoyaltyPoint entity)
    {
        const string sql = @"
            UPDATE LoyaltyPoints
            SET CustomerId = @CustomerId, TransactionId = @TransactionId, Points = @Points,
                EarnedDate = @EarnedDate, Month = @Month, Year = @Year
            WHERE Id = @Id";

        var affected = await _connection.ExecuteAsync(sql, entity, _transaction);
        return affected > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        const string sql = "DELETE FROM LoyaltyPoints WHERE Id = @Id";
        var affected = await _connection.ExecuteAsync(sql, new { Id = id }, _transaction);
        return affected > 0;
    }
}
