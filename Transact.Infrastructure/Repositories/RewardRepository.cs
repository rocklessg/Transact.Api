using System.Data;
using Dapper;
using Transac.Domain.Entities;
using Transac.Domain.Enums;
using Transac.Domain.Interfaces;

namespace Transact.Infrastructure.Repositories;

public class RewardRepository : IRewardRepository
{
    private readonly IDbConnection _connection;
    private IDbTransaction? _transaction;

    public RewardRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public void SetTransaction(IDbTransaction transaction)
    {
        _transaction = transaction;
    }

    public async Task<Reward?> GetByIdAsync(Guid id)
    {
        const string sql = @"
            SELECT Id, CustomerId, TransactionId, RewardType, Amount, AwardedDate, Month, Year, IsProcessed
            FROM Rewards
            WHERE Id = @Id";

        return await _connection.QueryFirstOrDefaultAsync<Reward>(sql, new { Id = id }, _transaction);
    }

    public async Task<bool> HasReceivedRewardForMonthAsync(Guid customerId, RewardType rewardType, int month, int year)
    {
        const string sql = @"
            SELECT COUNT(1)
            FROM Rewards
            WHERE CustomerId = @CustomerId AND RewardType = @RewardType AND Month = @Month AND Year = @Year";

        var count = await _connection.ExecuteScalarAsync<int>(sql, new 
        { 
            CustomerId = customerId, 
            RewardType = (int)rewardType, 
            Month = month, 
            Year = year 
        }, _transaction);

        return count > 0;
    }

    public async Task<Reward?> GetPendingFreeAirtimeRewardAsync(Guid customerId)
    {
        const string sql = @"
            SELECT Id, CustomerId, TransactionId, RewardType, Amount, AwardedDate, Month, Year, IsProcessed
            FROM Rewards
            WHERE CustomerId = @CustomerId AND RewardType = @RewardType AND IsProcessed = 0";

        return await _connection.QueryFirstOrDefaultAsync<Reward>(sql, new 
        { 
            CustomerId = customerId, 
            RewardType = (int)RewardType.FreeAirtime 
        }, _transaction);
    }

    public async Task<IEnumerable<Reward>> GetAllAsync()
    {
        const string sql = @"
            SELECT Id, CustomerId, TransactionId, RewardType, Amount, AwardedDate, Month, Year, IsProcessed
            FROM Rewards";

        return await _connection.QueryAsync<Reward>(sql, transaction: _transaction);
    }

    public async Task<Guid> AddAsync(Reward entity)
    {
        const string sql = @"
            INSERT INTO Rewards (Id, CustomerId, TransactionId, RewardType, Amount, AwardedDate, Month, Year, IsProcessed)
            VALUES (@Id, @CustomerId, @TransactionId, @RewardType, @Amount, @AwardedDate, @Month, @Year, @IsProcessed)";

        await _connection.ExecuteAsync(sql, entity, _transaction);
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(Reward entity)
    {
        const string sql = @"
            UPDATE Rewards
            SET CustomerId = @CustomerId, TransactionId = @TransactionId, RewardType = @RewardType,
                Amount = @Amount, AwardedDate = @AwardedDate, Month = @Month, Year = @Year, IsProcessed = @IsProcessed
            WHERE Id = @Id";

        var affected = await _connection.ExecuteAsync(sql, entity, _transaction);
        return affected > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        const string sql = "DELETE FROM Rewards WHERE Id = @Id";
        var affected = await _connection.ExecuteAsync(sql, new { Id = id }, _transaction);
        return affected > 0;
    }
}
