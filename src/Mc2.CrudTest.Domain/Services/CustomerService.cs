using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Exceptions;
using Mc2.CrudTest.Domain.Interfaces;

namespace Mc2.CrudTest.Domain.Services;

public class CustomerService : ICustomerService
{
    private readonly IDictionary<Guid, Customer> _customers;

    public CustomerService(IDictionary<Guid, Customer> customers)
    {
        _customers = customers;
    }

    public async Task<Customer?> GetCustomerAsync(Guid id, CancellationToken cancellationToken)
    {
        _customers.TryGetValue(id, out var customer);

        if (customer is null) throw new CustomerNotFoundException(id);

        return await Task.FromResult(customer);
    }

    public async Task<Customer> AddCustomerAsync(Customer customer, CancellationToken cancellationToken)
    {
        _customers.Add(customer.Id, customer);

        return await Task.FromResult(customer);
    }

    public Task<Customer> UpdateCustomerAsync(Customer customer, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCustomerAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}