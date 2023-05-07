using Mc2.CrudTest.Behavior.Drivers;
using OpenQA.Selenium;

namespace Mc2.CrudTest.Behavior.Pages;

public class EditCustomerPage
{
    private readonly IDriverFixture _driverFixture;

    public EditCustomerPage(IDriverFixture driverFixture)
    {
        _driverFixture = driverFixture;
    }
    
    IWebElement txtId => _driverFixture.Driver.FindElement(By.Id("txtId"));
    IWebElement TxtFirstName => _driverFixture.Driver.FindElement(By.Id("txtFirstName"));

    IWebElement TxtLastName => _driverFixture.Driver.FindElement(By.Id("txtLastName"));

    IWebElement TxtEmail => _driverFixture.Driver.FindElement(By.Id("txtEmail"));

    IWebElement TxtPhoneNumber => _driverFixture.Driver.FindElement(By.Id("txtPhoneNumber"));

    IWebElement TxtBankAccount => _driverFixture.Driver.FindElement(By.Id("txtBankAccountNumber"));

    IWebElement TxtDateOfBirth => _driverFixture.Driver.FindElement(By.Id("txtDateOfBirth"));

    IWebElement BtnSave => _driverFixture.Driver.FindElement(By.Id("btnSave"));
    
    
    public void UpdateCustomer(string firstName, string lastName, string email, string phoneNumber, string bankAccount,
        string dateOfBirth)
    {
        TxtFirstName.Clear();
        TxtFirstName.SendKeys(firstName);
        TxtLastName.SendKeys(lastName);
        TxtEmail.Clear();
        TxtEmail.SendKeys(email);
        TxtPhoneNumber.Clear();
        TxtPhoneNumber.SendKeys(phoneNumber);
        TxtBankAccount.Clear();
        TxtBankAccount.SendKeys(bankAccount);
        TxtDateOfBirth.Clear();
        TxtDateOfBirth.SendKeys(dateOfBirth);
        BtnSave.Click();
    }
}