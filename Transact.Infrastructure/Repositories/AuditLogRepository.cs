using System.Data;
using Dapper;
using Transac.Domain.Entities;
using Transac.Domain.Interfaces;

namespace Transact.Infrastructure.Repositories;

public class AuditLogRepository : IAuditLogRepository
{
    private readonly IDbConnection _connection;

    public AuditLogRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<Guid> AddAsync(AuditLog auditLog)
    {
        const string sql = @"
            INSERT INTO AuditLogs (Id, Endpoint, HttpMethod, RequestBody, ResponseBody, StatusCode, IpAddress, UserAgent, Timestamp, ExecutionTimeMs)
            VALUES (@Id, @Endpoint, @HttpMethod, @RequestBody, @ResponseBody, @StatusCode, @IpAddress, @UserAgent, @Timestamp, @ExecutionTimeMs)";

        auditLog.Id = Guid.NewGuid();
        await _connection.ExecuteAsync(sql, auditLog);
        return auditLog.Id;
    }
}
