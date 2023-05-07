using Mc2.CrudTest.Behavior.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Mc2.CrudTest.Behavior.Drivers;


public interface IDriverFixture
{
    IWebDriver Driver { get; }
}

public class DriverFixture : IDriverFixture
{
    private readonly IWebDriver _driver;

    public DriverFixture(Settings settings)
    {
        _driver = GetDriver();  
        _driver.Navigate().GoToUrl(settings.ApplicationUrl);
    }


    public IWebDriver Driver => _driver;

    private IWebDriver GetDriver()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        return new ChromeDriver();
    }
}