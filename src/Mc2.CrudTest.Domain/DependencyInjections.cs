using Mc2.CrudTest.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Domain;

public static class DependencyInjections
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, ICustomerService>();
        
        return services;
    }
}