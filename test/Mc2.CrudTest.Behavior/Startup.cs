using Mc2.CrudTest.Behavior.Drivers;
using Mc2.CrudTest.Behavior.Support;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;

namespace Mc2.CrudTest.Behavior;

public class Startup
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton(new Settings
        {
            ApplicationUrl = new Uri("https://localhost:5001")
        });

        services.AddScoped<IDriverFixture, DriverFixture>();

        return services;
    }
}