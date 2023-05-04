using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Testcontainers.MsSql;
using Xunit;

namespace Mc2.CrudTest.IntegrationTest;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram>, IAsyncLifetime
    where TProgram : class
{
    private readonly MsSqlContainer _container;
    private readonly IConfiguration _configuration;

    public CustomWebApplicationFactory()
    {
        _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json").Build();
        
        _container = new MsSqlBuilder()
            .WithEnvironment("ACCEPT_EULA", "Y")
            .WithPassword("123qweWE")
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .WithPortBinding(1433,true)
            .WithCleanUp(true)
            .Build();
    }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //ensure that the connection string is pointing to the container and not conflict with the local db
        _configuration["ConnectionStrings:McTestContext"] =
            $"Server=.,{_container.GetMappedPublicPort(1433)};Initial Catalog =McTestContext;MultipleActiveResultSets=true;User ID=sa;Password=123qweWE;Encrypt=False";
       
        builder.UseEnvironment("Development");
        
        builder.UseConfiguration(_configuration);
        
    }

    public async Task InitializeAsync()
    {
        await _container.StartAsync();
    }

    public new async Task DisposeAsync()
    {
        await _container.DisposeAsync();
    }
}