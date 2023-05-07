using TechTalk.SpecFlow;

namespace Mc2.CrudTest.Behavior.Steps;

[Binding]
public class CustomerManagerSteps
{
    private readonly List<ErrorCodes> _errorCodes = new();
    
    [Given(@"system error codes are following")]
    public void GivenSystemErrorCodesAreFollowing(Table table)
    {
        foreach (var row in table.Rows)
        {
            _errorCodes.Add(new ErrorCodes(int.Parse(row["Code"]), row["Description"]));
        }
    }

    [Given(@"platform has ""(.*)"" customers")]
    public void GivenPlatformHasCustomers(string p0)
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"user creates a customer with following data by sending '(.*)'")]
    public void WhenUserCreatesACustomerWithFollowingDataBySending(string p0, Table table)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"user can query to get all customers and must have ""(.*)"" record with following data")]
    public void ThenUserCanQueryToGetAllCustomersAndMustHaveRecordWithFollowingData(string p0, Table table)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"user must receive error codes")]
    public void ThenUserMustReceiveErrorCodes(Table table)
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"user edit customer with new data")]
    public void WhenUserEditCustomerWithNewData(Table table)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"user can lookup all customers and filter by below properties and get ""(.*)"" records")]
    public void ThenUserCanLookupAllCustomersAndFilterByBelowPropertiesAndGetRecords(string p0, Table table)
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"user delete customer by email of ""(.*)""")]
    public void WhenUserDeleteCustomerByEmailOf(string p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"user can query to get all customers and must have ""(.*)"" records")]
    public void ThenUserCanQueryToGetAllCustomersAndMustHaveRecords(string p0)
    {
        ScenarioContext.StepIsPending();
    }
    
    private sealed record ErrorCodes(int Code, string Description);
}