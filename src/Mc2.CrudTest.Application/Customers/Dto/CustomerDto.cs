namespace Mc2.CrudTest.Application.Customers.Dto;

public sealed record CustomerDto(Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string BankAccountNumber,
    DateTime DateOfBirth);