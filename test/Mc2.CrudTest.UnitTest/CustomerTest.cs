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
        var customer = new Customer(Guid.NewGuid(), "John", "Doe", "johndoe@gmaill.com", "989107602786", "1234567890",
            DateTime.Today);

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
}