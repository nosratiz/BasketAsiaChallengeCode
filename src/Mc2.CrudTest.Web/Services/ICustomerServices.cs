using Mc2.CrudTest.Web.Dto;
using Mc2.CrudTest.Web.Models;

namespace Mc2.CrudTest.Web.Services;

public interface ICustomerWebServices
{
    Task<List<CustomerDto>?> GetCustomerListAsync(CancellationToken cancellationToken);
   
    Task<CustomerDto?> GetCustomerAsync(Guid id, CancellationToken cancellationToken);
    
    Task<CreateCustomerViewModel> AddCustomerAsync(CreateCustomerDto customer, CancellationToken cancellationToken);
    
    Task<CustomerDto?> UpdateCustomerAsync(UpdateCustomerDto customer, CancellationToken cancellationToken);
    
    Task DeleteCustomerAsync(Guid id, CancellationToken cancellationToken);
}