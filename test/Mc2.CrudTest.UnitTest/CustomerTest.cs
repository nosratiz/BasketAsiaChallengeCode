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
        var customer = new Customer( Guid.NewGuid(),"John", "Doe", "johndoe@gmaill.com", "1234567890",DateTime.Today);
        
        _customerRepository
            .Setup(x => x.GetCustomerAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(customer);
        
        var result = _customerRepository.Object.GetCustomerAsync(Guid.NewGuid(), CancellationToken.None);

        result.Should().NotBeNull();
        
        result.Result.Should().Be(customer);
    }
    
    
    
    
    
}