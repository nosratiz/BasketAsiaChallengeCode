using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Application.Systems;

public sealed class SeedData
{
    private readonly IMcTestContext _context;

    public SeedData(IMcTestContext context)
    {
        _context = context;
    }

    public async Task SeedAllAsync(CancellationToken cancellationToken)
    {
        if (await _context.Customers.AnyAsync(cancellationToken) == false)
        {
            var customers = new List<Customer>();

            customers.Add(new Customer(Guid.NewGuid(), $"John", $"Doe", new Email($"johnDoe@gmail.com"),
             new PhoneNumber($"+989121234567"), $"12345678", DateTime.Now));

            await _context.Customers.AddRangeAsync(customers, cancellationToken);

            await _context.SaveAsync(cancellationToken);

        }
    }


}