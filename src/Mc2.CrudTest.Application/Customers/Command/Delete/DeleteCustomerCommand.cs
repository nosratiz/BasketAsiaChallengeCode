using MediatR;

namespace Mc2.CrudTest.Application.Customers.Command.Delete;

public sealed class DeleteCustomerCommand : IRequest
{
    public Guid Id { get; set; }
}