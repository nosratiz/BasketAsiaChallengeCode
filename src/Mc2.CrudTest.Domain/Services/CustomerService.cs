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

    public async Task<Customer> AddCustomerAsync(Customer createCustomer, CancellationToken cancellationToken)
    {
        _customers.Add(createCustomer.Id, createCustomer);

        return await Task.FromResult(createCustomer);
    }

    public async Task<Customer> UpdateCustomerAsync(Customer updateCustomer, CancellationToken cancellationToken)
    {
        _customers.TryGetValue(updateCustomer.Id, out var customer);

        if (customer is null) throw new CustomerNotFoundException(updateCustomer.Id);

        _customers[customer.Id] = customer;

        return await Task.FromResult(customer);
    }

    public async Task DeleteCustomerAsync(Guid id, CancellationToken cancellationToken)
    {
        _customers.TryGetValue(id, out var customer);

        if (customer is null) throw new CustomerNotFoundException(id);

        _customers.Remove(customer.Id);

        await Task.CompletedTask;
    }
}