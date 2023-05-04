using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Application.Common.Interfaces;

public interface IMcTestContext
{
    DbSet<Customer> Customers { get; set; }
    
    Task SaveAsync(CancellationToken cancellationToken);
}