namespace Transac.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICustomerRepository Customers { get; }
    IAccountRepository Accounts { get; }
    ITransactionRepository Transactions { get; }
    ILoyaltyPointRepository LoyaltyPoints { get; }
    IRewardRepository Rewards { get; }
    IAuditLogRepository AuditLogs { get; }
    
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
