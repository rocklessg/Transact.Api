using Microsoft.Extensions.DependencyInjection;
using Transact.Application.DTOs.Requests;
using Transact.Application.Interfaces;
using Transact.Application.Services;
using Transact.Application.Validators;

namespace Transact.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<ILoyaltyService, LoyaltyService>();

        services.AddScoped<IValidator<TransferRequest>, TransferRequestValidator>();
        services.AddScoped<IValidator<BuyAirtimeRequest>, BuyAirtimeRequestValidator>();

        return services;
    }
}
