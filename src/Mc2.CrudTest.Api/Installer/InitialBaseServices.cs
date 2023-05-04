using Mc2.CrudTest.Application.Systems;
using Mc2.CrudTest.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Api.Installer;

public static class InitialDatabaseServices
{
    public static async Task Init(WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();

        var services = serviceScope.ServiceProvider;
        var context = services.GetRequiredService<McTestContext>();
        await context.Database.MigrateAsync();

        var mediator = services.GetRequiredService<IMediator>();
        await mediator.Send(new SampleSeedDataCommand(), CancellationToken.None);
        
    }
}
