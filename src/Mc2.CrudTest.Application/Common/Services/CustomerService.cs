using AutoMapper;
using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Exceptions;
using Mc2.CrudTest.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly IMcTestContext _context;
    private readonly IMapper _mapper;

    public CustomerService(IMcTestContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Customer>> GetCustomerListAsync(CancellationToken cancellationToken)
       => await _context.Customers.ToListAsync(cancellationToken);


    public async Task<Customer?> GetCustomerAsync(Guid id, CancellationToken cancellationToken)
    {
        var customer = await _context
        .Customers
        .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (customer is null) throw new CustomerNotFoundException(id);

        return  customer;
    }

    public async Task<Customer> AddCustomerAsync(Customer createCustomer, CancellationToken cancellationToken)
    {
        await _context.Customers.AddAsync(createCustomer, cancellationToken);

        await _context.SaveAsync(cancellationToken);

        return createCustomer;
    }

    public async Task<Customer> UpdateCustomerAsync(Customer updateCustomer, CancellationToken cancellationToken)
    {
        var customer = await _context
        .Customers
        .FirstOrDefaultAsync(x => x.Id == updateCustomer.Id, cancellationToken);

        if (customer is null) throw new CustomerNotFoundException(updateCustomer.Id);

        _mapper.Map(updateCustomer, customer);

        await _context.SaveAsync(cancellationToken);

        return customer;
    }

    public async Task DeleteCustomerAsync(Guid id, CancellationToken cancellationToken)
    {
        var customer = await _context
       .Customers
       .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (customer is null) throw new CustomerNotFoundException(id);

        _context.Customers.Remove(customer);

        await _context.SaveAsync(cancellationToken);

        await Task.CompletedTask;
    }
}