using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Domain.Entities;
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

            for (var i = 0; i < 10; i++)
            {
                customers.Add(new Customer(Guid.NewGuid(), $"John{i}", $"Doe{i}", $"johnDoe{i}@gmail.com",
                 $"0912345678{i}", $"12345678{i}", DateTime.Now));
            }
            await _context.Customers.AddRangeAsync(customers, cancellationToken);

            await _context.SaveAsync(cancellationToken);

        }
    }


}