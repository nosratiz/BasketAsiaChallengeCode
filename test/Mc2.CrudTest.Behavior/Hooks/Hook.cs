using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.Behavior.Hooks;

[Binding]
public sealed class Hook
{
    private Process _apiProcess;
    private Process _WebProcess;

    [BeforeFeature("CreateReadEditDeleteCustomer")]
    public void BeforeFeature()
    {
        _apiProcess = Process.Start("dotnet", "run --project ../Mc2.CrudTest.Api/Mc2.CrudTest.Api.csproj");
        _WebProcess = Process.Start("dotnet", "run --project ../Mc2.CrudTest.Web/Mc2.CrudTest.Web.csproj");
    }
    
    [AfterFeature("CreateReadEditDeleteCustomer")]
    public void AfterFeature()
    {
        _apiProcess.Kill();
        _WebProcess.Kill();
    }
}