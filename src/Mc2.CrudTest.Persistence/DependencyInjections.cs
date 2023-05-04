using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Persistence;

public static class DependencyInjections
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<McTestContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("McTestContext"),
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        10,
                        TimeSpan.FromSeconds(3),
                        null);
                });

            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
            options.ConfigureWarnings(warningLog =>
            {
                warningLog.Log(CoreEventId.FirstWithoutOrderByAndFilterWarning,
                    CoreEventId.RowLimitingOperationWithoutOrderByWarning);
            });
        });


        services.AddScoped<IMcTestContext>(provider => provider.GetService<McTestContext>()!);
    }
}