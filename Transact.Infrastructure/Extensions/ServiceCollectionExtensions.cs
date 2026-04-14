using System.Data;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Transac.Domain.Enums;
using Transac.Domain.Interfaces;
using Transact.Infrastructure.Data;

namespace Transact.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        SqlMapper.AddTypeHandler(new CustomerTypeHandler());

        services.AddSingleton<IDbConnectionFactory, SqlConnectionFactory>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}

public class CustomerTypeHandler : SqlMapper.TypeHandler<CustomerType>
{
    public override void SetValue(IDbDataParameter parameter, CustomerType value)
    {
        parameter.Value = value.ToString().ToUpper();
    }

    public override CustomerType Parse(object value)
    {
        return value.ToString()?.ToUpper() switch
        {
            "BUSINESS" => CustomerType.Business,
            "RETAIL" => CustomerType.Retail,
            _ => throw new ArgumentException($"Unknown customer type: {value}")
        };
    }
}
