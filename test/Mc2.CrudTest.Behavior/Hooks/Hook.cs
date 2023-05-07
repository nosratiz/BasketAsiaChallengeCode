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
    private static Process? _apiProcess;
    private static Process? _webProcess;

    [BeforeFeature("CreateReadEditDeleteCustomer")]
    public static void BeforeFeature()
    {
        _apiProcess = Process.Start("dotnet", "run --project ../Mc2.CrudTest.Api/Mc2.CrudTest.Api.csproj");
        _webProcess = Process.Start("dotnet", "run --project ../Mc2.CrudTest.Web/Mc2.CrudTest.Web.csproj");
    }
    
    [AfterFeature("CreateReadEditDeleteCustomer")]
    public static void AfterFeature()
    {
        _apiProcess?.Kill();
        _webProcess?.Kill();
    }
}