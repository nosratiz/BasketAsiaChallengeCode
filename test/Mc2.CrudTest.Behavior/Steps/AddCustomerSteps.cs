using FluentAssertions;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Interfaces;
using Mc2.CrudTest.Domain.ValueObjects;
using Moq;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.Behavior.Steps;

[Binding]
public class AddCustomerSteps
{
    private readonly Mock<ICustomerService> _customerService;

    public AddCustomerSteps()
    {
        _customerService = new Mock<ICustomerService>();
    }


    [Given(@"see the customer list")]
    public async Task GivenSeeTheCustomerList()
    {
        _customerService.Setup(x => x.GetCustomerListAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Customer>());

        var result = await _customerService.Object.GetCustomerListAsync(CancellationToken.None);

        result.Should().BeOfType<List<Customer>>();
    }

    [When(@"I add a customer information like I enter the following customer information:")]
    public async Task WhenIAddACustomerInformationLikeIEnterTheFollowingCustomerInformation(Table table)
    {
        
        var firstName = table.Rows[0]["FirstName"];
        var lastName = table.Rows[0]["LastName"];
        var email = table.Rows[0]["Email"];
        var phoneNumber = table.Rows[0]["PhoneNumber"];
        var bankAccountNumber = table.Rows[0]["BankAccountNumber"];
        var dateOfBirth = DateTime.Parse(table.Rows[0]["DateOfBirth"]);
        
        var customer = new Customer(Guid.NewGuid(), firstName, lastName, new Email(email), new PhoneNumber(phoneNumber), bankAccountNumber, dateOfBirth);

        _customerService.Setup(x => x.AddCustomerAsync(customer, It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        var customerResult = await _customerService.Object.AddCustomerAsync(customer, CancellationToken.None);

        customerResult.Should().NotBeNull();

        customerResult.Should().Be(customer);
    }


    [Then(@"the customer list should contain (.*) customer")]
    public async Task ThenTheCustomerListShouldContainCustomer(int p0)
    {
        _customerService.Setup(x => x.GetCustomerListAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Customer>
            {
                new(Guid.NewGuid(), "John", "Doe", new Email("john@example.com"), new PhoneNumber("+989107602786"), "123456789", DateTime.Now)
            });


        var result = await _customerService.Object.GetCustomerListAsync(CancellationToken.None);

        result.Should().HaveCount(p0);
    }
}