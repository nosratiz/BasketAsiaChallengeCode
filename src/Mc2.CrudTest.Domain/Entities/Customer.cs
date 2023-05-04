using Ardalis.GuardClauses;

namespace Mc2.CrudTest.Domain.Entities;

public sealed class Customer 
{
    public Customer( string firstName, string lastName,
        string email, string bankAccountNumber, DateTime dateOfBirth) 
    {
        FirstName = Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName));
        LastName = Guard.Against.NullOrWhiteSpace(lastName, nameof(lastName));
        Email = Guard.Against.NullOrWhiteSpace(email, nameof(email));
        BankAccountNumber = Guard.Against.NullOrWhiteSpace(bankAccountNumber, nameof(bankAccountNumber));
        DateOfBirth = Guard.Against.Default(dateOfBirth, nameof(dateOfBirth)); 
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; private set; }
    public string BankAccountNumber { get; private set; }
    public DateTime DateOfBirth { get; private set; }


    public override string ToString() => $"{FirstName} {LastName}";
}