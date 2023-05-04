using FluentAssertions;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Exceptions;
using Mc2.CrudTest.Domain.Interfaces;
using Moq;
using Xunit;

namespace Mc2.CrudTest.UnitTest;

public class CustomerTest
{
    private readonly Mock<ICustomerService> _customerRepository;

    public CustomerTest()
    {
        _customerRepository = new Mock<ICustomerService>();
    }


    [Fact]
    public void GivenAnInvalidCustomerId_ThenThrow_CustomerNotFoundException()
    {
        _customerRepository
            .Setup(x => x.GetCustomerAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .Throws(new CustomerNotFoundException(Guid.NewGuid()));

        Action act = () => _customerRepository.Object.GetCustomerAsync(Guid.NewGuid(), CancellationToken.None);

        act.Should().Throw<CustomerNotFoundException>();
    }


    [Fact]
    public void GivenAValidCustomerId_ThenReturn_Customer()
    {
        var customer = UserFakeData.CreateUserCommand();

        _customerRepository
            .Setup(x => x.GetCustomerAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        var result = _customerRepository.Object.GetCustomerAsync(Guid.NewGuid(), CancellationToken.None);

        result.Should().NotBeNull();

        result.Result.Should().Be(customer);
    }


    [Theory]
    [ClassData(typeof(UserFakeData.CreateUserTestData))]
    public void AddInvalidCustomer_ThenThrow_ArgumentException(Guid id, string firsName, string lastName, string email,
        string phoneNumber, string bankAccountNumber, DateTime dateOfBirth)
    {
        Action act = () =>
        {
            _ = new Customer(id, firsName, lastName, email, phoneNumber, bankAccountNumber, dateOfBirth);
        };

        act.Should().Throw<ArgumentException>();
    }


    [Fact]
    public async Task AddValidCustomer_ThenReturn_Customer()
    {
        var customer = UserFakeData.CreateUserCommand();

        _customerRepository
            .Setup(x => x.AddCustomerAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        var result = await _customerRepository.Object.AddCustomerAsync(customer, CancellationToken.None);

        result.Should().NotBeNull();

        result.Should().Be(customer);
    }
    
    
    [Fact]
    public async Task UpdateValidCustomer_ThenReturn_Customer()
    {
        var customer = UserFakeData.CreateUserCommand();

        _customerRepository
            .Setup(x => x.UpdateCustomerAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        var result = await _customerRepository.Object.UpdateCustomerAsync(customer, CancellationToken.None);

        result.Should().NotBeNull();

        result.Should().Be(customer);
    }
    
    [Fact]
    public async Task DeleteValidCustomer_ThenReturn_Customer()
    {
        var customer = UserFakeData.CreateUserCommand();
        
        _customerRepository.Setup(x => x.AddCustomerAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);

        _customerRepository
            .Setup(x => x.DeleteCustomerAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        await _customerRepository.Object.DeleteCustomerAsync(customer.Id, CancellationToken.None);
        
        
        _customerRepository
            .Setup(x => x.GetCustomerAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .Throws(new CustomerNotFoundException(customer.Id));
        
        Action act = () => _customerRepository.Object.GetCustomerAsync(customer.Id, CancellationToken.None);
        
        act.Should().Throw<CustomerNotFoundException>();
        
    }
    
    
}