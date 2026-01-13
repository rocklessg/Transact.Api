using Microsoft.Extensions.DependencyInjection;
using Transac.Domain.Interfaces;
using Transact.Infrastructure.Data;

namespace Transact.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IDbConnectionFactory, SqlConnectionFactory>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
