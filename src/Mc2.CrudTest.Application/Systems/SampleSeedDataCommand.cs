using Mc2.CrudTest.Application.Common.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Application.Systems;

public sealed class SampleSeedDataCommand : IRequest
{

}

public sealed class SampleSeedDataCommandHandler : IRequestHandler<SampleSeedDataCommand>
{
    private readonly IMcTestContext _context;

    public SampleSeedDataCommandHandler(IMcTestContext context)
    {
        _context = context;
    }

    public async Task Handle(SampleSeedDataCommand request, CancellationToken cancellationToken)
    {
        var seeder = new SeedData(_context);

        await seeder.SeedAllAsync(cancellationToken);
    }
}