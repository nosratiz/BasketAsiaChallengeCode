using Mc2.CrudTest.Api.Installer;
using Xunit;

namespace Mc2.CrudTest.IntegrationTest;

public class IntegrationTestBase : IClassFixture<CustomWebApplicationFactory<IInstaller>>
{
    protected readonly HttpClient HttpClient;
    public IntegrationTestBase(CustomWebApplicationFactory<IInstaller> factory)
    {
        HttpClient = factory.CreateClient();
    }
}