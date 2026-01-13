using System.Data;
using Transac.Domain.Interfaces;
using Transact.Infrastructure.Repositories;

namespace Transact.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDbConnection _connection;
    private IDbTransaction? _transaction;
    private bool _disposed;

    private CustomerRepository? _customerRepository;
    private AccountRepository? _accountRepository;
    private TransactionRepository? _transactionRepository;
    private LoyaltyPointRepository? _loyaltyPointRepository;
    private RewardRepository? _rewardRepository;
    private AuditLogRepository? _auditLogRepository;

    public UnitOfWork(IDbConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.CreateConnection();
        _connection.Open();
    }

    public ICustomerRepository Customers
    {
        get
        {
            _customerRepository ??= new CustomerRepository(_connection);
            if (_transaction != null)
                _customerRepository.SetTransaction(_transaction);
            return _customerRepository;
        }
    }

    public IAccountRepository Accounts
    {
        get
        {
            _accountRepository ??= new AccountRepository(_connection);
            if (_transaction != null)
                _accountRepository.SetTransaction(_transaction);
            return _accountRepository;
        }
    }

    public ITransactionRepository Transactions
    {
        get
        {
            _transactionRepository ??= new TransactionRepository(_connection);
            if (_transaction != null)
                _transactionRepository.SetTransaction(_transaction);
            return _transactionRepository;
        }
    }

    public ILoyaltyPointRepository LoyaltyPoints
    {
        get
        {
            _loyaltyPointRepository ??= new LoyaltyPointRepository(_connection);
            if (_transaction != null)
                _loyaltyPointRepository.SetTransaction(_transaction);
            return _loyaltyPointRepository;
        }
    }

    public IRewardRepository Rewards
    {
        get
        {
            _rewardRepository ??= new RewardRepository(_connection);
            if (_transaction != null)
                _rewardRepository.SetTransaction(_transaction);
            return _rewardRepository;
        }
    }

    public IAuditLogRepository AuditLogs
    {
        get
        {
            _auditLogRepository ??= new AuditLogRepository(_connection);
            return _auditLogRepository;
        }
    }

    public Task BeginTransactionAsync()
    {
        _transaction = _connection.BeginTransaction();
        return Task.CompletedTask;
    }

    public Task CommitAsync()
    {
        _transaction?.Commit();
        _transaction?.Dispose();
        _transaction = null;
        return Task.CompletedTask;
    }

    public Task RollbackAsync()
    {
        _transaction?.Rollback();
        _transaction?.Dispose();
        _transaction = null;
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _transaction?.Dispose();
                _connection?.Dispose();
            }
            _disposed = true;
        }
    }
}
