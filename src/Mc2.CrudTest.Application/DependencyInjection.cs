using System.Reflection;
using FluentValidation;
using Mc2.CrudTest.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssemblyContaining(typeof(IMcTestContext));


        return services;
    }
}