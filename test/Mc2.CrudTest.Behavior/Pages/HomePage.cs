using Mc2.CrudTest.Behavior.Drivers;
using OpenQA.Selenium;

namespace Mc2.CrudTest.Behavior.Pages;

public class HomePage
{
    private readonly IDriverFixture _driverFixture;

    public HomePage(IDriverFixture driverFixture)
    {
        _driverFixture = driverFixture;
    }

    IWebElement LnkAddCustomer => _driverFixture.Driver.FindElement(By.Id("lnkAddCustomer"));

    private IWebElement TblCustomers => _driverFixture.Driver.FindElement(By.Id("tblCustomers"));

    public void ClickAddCustomer()
    {
        LnkAddCustomer.Click();
    }

    public bool CountCustomers(int count)
    {
        //since we use on tr in header we need to subtract 1
        int resultCount= TblCustomers.FindElements(By.TagName("tr")).Count - 1;
        return resultCount == count;
    }
    
    public bool CustomerSearch( string email)
    {
        //since email is unique we can search by email
        var result = TblCustomers.FindElements(By.TagName("tbody"));
       
        foreach (var row in result)
        {
            var cells = row.FindElements(By.TagName("td"));
            if (cells[2].Text == email )
            {
                return true;
            }
        }

        return false;
    }

    public int CustomerSearchCount(string email)
    {
        var result = TblCustomers.FindElements(By.TagName("tbody"));
        int count = 0;
        foreach (var row in result)
        {
            var cells = row.FindElements(By.TagName("td"));
            if (cells[2].Text == email )
            {
                count++;
            }
        }

        return count;
    }
    
    IWebElement BtnEdit => _driverFixture.Driver.FindElement(By.Id("btnEdit"));

    IWebElement BtnDelete => _driverFixture.Driver.FindElement(By.Id("btnDelete"));
    
    public void EditCustomer()
    {
        BtnEdit.Click();
    }
    
    public void DeleteCustomer()
    {
        BtnDelete.Click();
    }
}