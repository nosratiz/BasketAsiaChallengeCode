using FluentAssertions;
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
    
    
}