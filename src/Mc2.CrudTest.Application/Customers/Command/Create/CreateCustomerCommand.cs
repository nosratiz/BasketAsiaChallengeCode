using Mc2.CrudTest.Application.Customers.Dto;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.Command.Create;


public sealed class CreateCustomerCommand : IRequest<CustomerDto>
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public string BankAccountNumber { get; init; } = null!;
    public DateTime DateOfBirth { get; init; }
}
