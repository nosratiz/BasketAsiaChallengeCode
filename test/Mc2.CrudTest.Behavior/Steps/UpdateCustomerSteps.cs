using FluentAssertions;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Interfaces;
using Mc2.CrudTest.Domain.ValueObjects;
using Moq;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.Behavior.Steps;

[Binding]
public class UpdateCustomerSteps
{
    private readonly Mock<ICustomerService> _customerService;

    public UpdateCustomerSteps()
    {
        _customerService = new Mock<ICustomerService>();
    }

    [Given(@"I have a customer with the following attributes:")]
    public async Task GivenIHaveACustomerWithTheFollowingAttributes(Table table)
    {
        var id = Guid.Parse(table.Rows[0]["Id"]);
       var firstName = table.Rows[0]["FirstName"];
        var lastName = table.Rows[0]["LastName"];
        var email = table.Rows[0]["Email"];
        var phoneNumber = table.Rows[0]["PhoneNumber"];
        var bankAccountNumber = table.Rows[0]["BankAccountNumber"];
        var dateOfBirth = DateTime.Parse(table.Rows[0]["DateOfBirth"]);
        
        var customer = new Customer(id, firstName, lastName, new Email(email), new PhoneNumber(phoneNumber), bankAccountNumber, dateOfBirth);

        _customerService.Setup(x => x.AddCustomerAsync(customer, It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        var customerResult = await _customerService.Object.AddCustomerAsync(customer, CancellationToken.None);

        customerResult.Should().NotBeNull();

        customerResult.Should().Be(customer);
    }

    [When(@"I update the customer with the following attributes:")]
    public async Task WhenIUpdateTheCustomerWithTheFollowingAttributes(Table table)
    {
        var id = Guid.Parse(table.Rows[0]["Id"]);
        var firstName = table.Rows[0]["FirstName"];
        var lastName = table.Rows[0]["LastName"];
        var email = table.Rows[0]["Email"];
        var phoneNumber = table.Rows[0]["PhoneNumber"];
        var bankAccountNumber = table.Rows[0]["BankAccountNumber"];
        var dateOfBirth = DateTime.Parse(table.Rows[0]["DateOfBirth"]);
        
        var customer = new Customer(id, firstName, lastName, new Email(email), new PhoneNumber(phoneNumber), bankAccountNumber, dateOfBirth);
        
        _customerService.Setup(x => x.UpdateCustomerAsync(customer, It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);
        
        var customerResult =await _customerService.Object.UpdateCustomerAsync(customer, CancellationToken.None);
        
        
        customerResult.Should().NotBeNull();
        
        customerResult.Should().Be(customer);
    }

    [Then(@"the customer should be updated with the following attributes:")]
    public async Task ThenTheCustomerShouldBeUpdatedWithTheFollowingAttributes(Table table)
    {
        var id = Guid.Parse(table.Rows[0]["Id"]);
        
        _customerService.Setup(x => x.GetCustomerAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Customer(id, table.Rows[0]["FirstName"], 
                table.Rows[0]["LastName"], new Email(table.Rows[0]["Email"]), 
                new PhoneNumber(table.Rows[0]["PhoneNumber"]), table.Rows[0]["BankAccountNumber"], 
                DateTime.Parse(table.Rows[0]["DateOfBirth"])));
        
        var customerResult = await _customerService.Object.GetCustomerAsync(id, CancellationToken.None);
        
        customerResult.Should().NotBeNull();
        
        customerResult.Should().BeOfType<Customer>();
        
        customerResult?.Id.Should().Be(id);
        
        customerResult?.FirstName.Should().Be(table.Rows[0]["FirstName"]);
    }
}