using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Persistence.Contexts;

public class McTestContext : DbContext, IMcTestContext
{
    public McTestContext()
    {

    }
    public McTestContext(DbContextOptions<McTestContext> options) : base(options)
    {
    }

    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Initial Catalog =McTestContext;MultipleActiveResultSets=true;User ID=sa;Password=123qweWE;Max Pool Size=1000;Pooling=true;Encrypt=False");
        }
    }

    public DbSet<Customer> Customers { get; set; }

    public Task SaveAsync(CancellationToken cancellationToken) => SaveChangesAsync(cancellationToken);

    
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(McTestContext).Assembly);
}