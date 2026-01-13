using Transac.Domain.Entities;

namespace Transac.Domain.Interfaces;

public interface IAuditLogRepository
{
    Task<Guid> AddAsync(AuditLog auditLog);
}
