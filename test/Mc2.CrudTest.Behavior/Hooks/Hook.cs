using System.Diagnostics;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.Behavior.Hooks;

[Binding]
public sealed class Hook
{
    private static Process? _apiProcess;
    private static Process? _webProcess;
   
    
    [BeforeScenario("CreateReadEditDeleteCustomer")]
    public async Task BeforeScenario()
    {
        _apiProcess = Process.Start("dotnet", "run --project src/src/Mc2.CrudTest.Api/Mc2.CrudTest.Api.csproj");
        _webProcess = Process.Start("dotnet", "run --project src/src/Mc2.CrudTest.Web/Mc2.CrudTest.Web.csproj");
    }

    [AfterScenario("CreateReadEditDeleteCustomer")]
    public void AfterScenario()
    {
        _apiProcess?.Kill();
        _webProcess?.Kill();
    }
}