using Mc2.CrudTest.Behavior.Drivers;
using OpenQA.Selenium;

namespace Mc2.CrudTest.Behavior.Pages;

public class AddCustomerPage
{
    private readonly IDriverFixture _driverFixture;

    public AddCustomerPage(IDriverFixture driverFixture)
    {
        _driverFixture = driverFixture;
    }

    IWebElement TxtFirstName => _driverFixture.Driver.FindElement(By.Id("txtFirstName"));

    IWebElement TxtLastName => _driverFixture.Driver.FindElement(By.Id("txtLastName"));

    IWebElement TxtEmail => _driverFixture.Driver.FindElement(By.Id("txtEmail"));

    IWebElement TxtPhoneNumber => _driverFixture.Driver.FindElement(By.Id("txtPhoneNumber"));

    IWebElement TxtBankAccount => _driverFixture.Driver.FindElement(By.Id("txtBankAccountNumber"));

    IWebElement TxtDateOfBirth => _driverFixture.Driver.FindElement(By.Id("txtDateOfBirth"));

    IWebElement BtnSave => _driverFixture.Driver.FindElement(By.Id("btnSave"));

    IWebElement BtnBackToHomePage => _driverFixture.Driver.FindElement(By.Id("lnkHomePage"));

    IWebElement LblError201 => _driverFixture.Driver.FindElement(By.Id("lblError-201"));

    IWebElement LblError202 => _driverFixture.Driver.FindElement(By.Id("lblError-202"));

   

    public void AddCustomer(string firstName, string lastName, string email, string phoneNumber, string bankAccount,
        string dateOfBirth)
    {
        TxtFirstName.SendKeys(firstName);
        TxtLastName.SendKeys(lastName);
        TxtEmail.SendKeys(email);
        TxtPhoneNumber.SendKeys(phoneNumber);
        TxtBankAccount.SendKeys(bankAccount);
        TxtDateOfBirth.SendKeys(dateOfBirth);
        BtnSave.Click();
    }

    public bool ShowErrors(List<int> errorCode)
    {
        var result = false;

        foreach (var code in errorCode)
        {
            result = code switch
            {
                201 => LblError201.Displayed,
                202 => LblError202.Displayed,
                _ => result
            };
        }

        return result;
    }

    public void NavigateToHomePage()
    {
        BtnBackToHomePage.Click();
    }
    
  
}