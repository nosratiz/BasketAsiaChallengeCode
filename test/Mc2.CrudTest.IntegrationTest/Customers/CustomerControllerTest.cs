using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Mc2.CrudTest.Api.Installer;
using Mc2.CrudTest.Application.Customers.Command.Create;
using Mc2.CrudTest.Application.Customers.Command.Update;
using Mc2.CrudTest.Application.Customers.Dto;
using Xunit;

namespace Mc2.CrudTest.IntegrationTest.Customers;

public class CustomerControllerTest : IntegrationTestBase
{
    public CustomerControllerTest(CustomWebApplicationFactory<IInstaller> factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetCustomers_ReturnsSuccessResult()
    {
        var response = await HttpClient.GetAsync("/api/customers");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var result = await response.Content.ReadFromJsonAsync<List<CustomerDto>>();

        result.Should().NotBeNull();

        result.Should().HaveCount(10);

        result.Should().BeOfType<List<CustomerDto>>().Which.First().FirstName.Should().Contain("John");
    }


    [Fact]
    public async Task When_SendInvalidId_GetCustomerInfo_ReturnsNotFound()
    {
        var response = await HttpClient.GetAsync($"/api/customers/{Guid.NewGuid()}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task When_SendValidId_GetCustomerInfo_ReturnsSuccessResult()
    {
        var customerListResponse = await HttpClient.GetAsync("/api/customers");

        var customerList = await customerListResponse.Content.ReadFromJsonAsync<List<CustomerDto>>();

        var response = await HttpClient.GetAsync($"/api/customers/{customerList!.First().Id}");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var result = await response.Content.ReadFromJsonAsync<CustomerDto>();

        result.Should().NotBeNull();

        result.Should().BeOfType<CustomerDto>().Which.FirstName.Should().Contain("John");
    }
    
    [Fact]
    public async Task When_SendInvalidId_DeleteCustomer_ReturnsNotFound()
    {
        var response = await HttpClient.DeleteAsync($"/api/customers/{Guid.NewGuid()}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
    
    [Fact]
    public async Task When_SendValidId_DeleteCustomer_ReturnsSuccessResult()
    {
        var customerListResponse = await HttpClient.GetAsync("/api/customers");

        var customerList = await customerListResponse.Content.ReadFromJsonAsync<List<CustomerDto>>();

        var response = await HttpClient.DeleteAsync($"/api/customers/{customerList!.First().Id}");

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
    
    [Fact]
    public async Task When_SendInvalidData_UpdateCustomer_ReturnsBadRequest()
    {
        var response = await HttpClient.PutAsJsonAsync($"/api/customers",new UpdateCustomerCommand());

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task When_SendValidData_UpdateCustomer_ReturnsSuccessResult()
    {
        var customerListResponse = await HttpClient.GetAsync("/api/customers");

        var customerList = await customerListResponse.Content.ReadFromJsonAsync<List<CustomerDto>>();

        var response = await HttpClient.PutAsJsonAsync($"/api/customers", new UpdateCustomerCommand
        {
            FirstName = "nima",
            LastName = "nosrati",
            Email = "nima@gmai.com",
            PhoneNumber = "+18185338330",
            BankAccountNumber = "9823435664",
            DateOfBirth = DateTime.Now,
            Id = customerList!.First().Id
        });

        response.StatusCode.Should().Be(HttpStatusCode.OK);

    }
    
    [Fact]
    public async Task When_SendInvalidData_CreateCustomer_ReturnsBadRequest()
    {
        var response = await HttpClient.PostAsJsonAsync($"/api/customers",new CreateCustomerCommand());

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task When_SendValidData_CreateCustomer_ReturnsSuccessResult()
    {
        var response = await HttpClient.PostAsJsonAsync($"/api/customers", new CreateCustomerCommand
        {
            FirstName = "nima2",
            LastName = "nosrati",
            Email = "nima2@gmai.com",
            PhoneNumber = "+18185228330",
            BankAccountNumber = new Random().Next(100000000, 999999999).ToString(),
            DateOfBirth = DateTime.Now
        });

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var result = await response.Content.ReadFromJsonAsync<CustomerDto>();

        result.Should().NotBeNull();

        result.Should().BeOfType<CustomerDto>().Which.FirstName.Should().Contain("nima");
    }
}