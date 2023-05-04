using Mc2.CrudTest.Application.Customers.Dto;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.Command.Update;

public sealed class UpdateCustomerCommand : IRequest<CustomerDto>
{
    public Guid Id { get; init; }
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public string BankAccountNumber { get; init; } = null!;
    public DateTime DateOfBirth { get; init; }
}