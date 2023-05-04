using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Domain.Interfaces;

public interface ICustomerService
{
    Task<List<Customer>> GetCustomerListAsync(CancellationToken cancellationToken);
   
    Task<Customer?> GetCustomerAsync(Guid id, CancellationToken cancellationToken);
    
    Task<Customer> AddCustomerAsync(Customer customer, CancellationToken cancellationToken);
    
    Task<Customer> UpdateCustomerAsync(Customer customer, CancellationToken cancellationToken);
    
    Task DeleteCustomerAsync(Guid id, CancellationToken cancellationToken);
}