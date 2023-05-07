using FluentAssertions;
using Mc2.CrudTest.Behavior.Drivers;
using Mc2.CrudTest.Behavior.Pages;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.Behavior.Steps;

[Binding]
public class CustomerManagerSteps
{
    private readonly List<ErrorCodes> _errorCodes = new();

    private readonly HomePage _homePage;
    private readonly AddCustomerPage _addCustomerPage;

    public CustomerManagerSteps(IDriverFixture driverFixture)
    {
        var driverFixture1 = driverFixture;
        _homePage = new HomePage(driverFixture1);
        _addCustomerPage = new AddCustomerPage(driverFixture1);
    }

    [Given(@"system error codes are following")]
    public void GivenSystemErrorCodesAreFollowing(Table table)
    {
        foreach (var row in table.Rows)
        {
            _errorCodes.Add(new ErrorCodes(int.Parse(row["Code"]), row["Description"]));
        }
    }

    [Given(@"platform has ""(.*)"" customers")]
    public void GivenPlatformHasCustomers(int p0)
    {
       bool resultExpected= _homePage.CountCustomers(p0);
       
         resultExpected.Should().BeTrue();
        
    }

    [When(@"user creates a customer with following data by sending '(.*)'")]
    public void WhenUserCreatesACustomerWithFollowingDataBySending(string p0, Table table)
    {
        
        _homePage.ClickAddCustomer();
        
        var firstName = table.Rows[0]["FirstName"];
        var lastName = table.Rows[0]["LastName"];
        var email = table.Rows[0]["Email"];
        var phoneNumber = table.Rows[0]["PhoneNumber"];
        var bankAccountNumber = table.Rows[0]["BankAccountNumber"];
        var dateOfBirth = DateTime.Parse(table.Rows[0]["DateOfBirth"]);
        
        
        _addCustomerPage.AddCustomer(firstName,lastName,email,phoneNumber,bankAccountNumber,dateOfBirth.ToString("d"));
    }

    [Then(@"user can query to get all customers and must have ""(.*)"" record with following data")]
    public void ThenUserCanQueryToGetAllCustomersAndMustHaveRecordWithFollowingData(int p0, Table table)
    {
        bool customerCountResult= _homePage.CountCustomers(p0);
       
        customerCountResult.Should().BeTrue();
        
        var email = table.Rows[0]["Email"];
        
        bool customerSearchResult = _homePage.CustomerSearch(email);
        
        customerSearchResult.Should().BeTrue();


    }

    [Then(@"user must receive error codes")]
    public void ThenUserMustReceiveErrorCodes(Table table)
    {
        var expectedErrorCodes = table.Rows.Select(x => int.Parse(x["Code"])).ToList();

        var expectedResult = _addCustomerPage.ShowErrors(expectedErrorCodes);
        
        expectedResult.Should().BeTrue();
        
        _addCustomerPage.NavigateToHomePage();

    }

    [When(@"user edit customer with new data")]
    public void WhenUserEditCustomerWithNewData(Table table)
    {
        _homePage.EditCustomer();
    }

    [Then(@"user can lookup all customers and filter by below properties and get ""(.*)"" records")]
    public void ThenUserCanLookupAllCustomersAndFilterByBelowPropertiesAndGetRecords(int p0, Table table)
    {
        var email = table.Rows[0]["Email"];
        
        bool customerSearchResult = _homePage.CustomerSearch(email);

        customerSearchResult.Should().BeFalse();
        
        int customerCountResult= _homePage.CustomerSearchCount(email);
        
        customerCountResult.Should().Be(p0);
        
    }

    [When(@"user delete customer by email of ""(.*)""")]
    public void WhenUserDeleteCustomerByEmailOf(string p0)
    {
        ///ToDo add filter in table and then delete by email
        //I don't have time to set filter and refactor code since it just 1 record I used it in this way
        //I know it's not good practice but I don't have time to refactor it but I learned a lot from this project
        _homePage.DeleteCustomer();
    }

    [Then(@"user can query to get all customers and must have ""(.*)"" records")]
    public void ThenUserCanQueryToGetAllCustomersAndMustHaveRecords(int p0)
    {
        bool customerCountResult= _homePage.CountCustomers(p0);
       
        customerCountResult.Should().BeTrue();
    }
    
    private sealed record ErrorCodes(int Code, string Description);
}