using Mc2.CrudTest.Domain.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.Command.Delete;

public sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly ICustomerService _customerService;

    public DeleteCustomerCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        await _customerService.DeleteCustomerAsync(request.Id, cancellationToken);
    }
}