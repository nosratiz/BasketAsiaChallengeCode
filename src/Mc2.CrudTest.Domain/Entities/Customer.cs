using Ardalis.GuardClauses;
using Mc2.CrudTest.Domain.Primitives;
using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Domain.Entities;

public sealed class Customer : Entity
{
    public Customer(Guid id, string firstName, string lastName,
        Email email,PhoneNumber phoneNumber,  string bankAccountNumber, DateTime dateOfBirth) : base(id)
    {
        FirstName = Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName));
        LastName = Guard.Against.NullOrWhiteSpace(lastName, nameof(lastName));
        
        Email = Guard.Against.Null(email, nameof(email));
       
        PhoneNumber = Guard.Against.Null(phoneNumber, nameof(phoneNumber));
        
        BankAccountNumber = Guard.Against.NullOrWhiteSpace(bankAccountNumber, nameof(bankAccountNumber));
       
        DateOfBirth = Guard.Against.Default(dateOfBirth, nameof(dateOfBirth));
    }

    private Customer(){}

    public string FirstName { get; }
    public string LastName { get; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Email Email { get; private set; }
    public string BankAccountNumber { get; private set; }

    public DateTime DateOfBirth { get; private set; }


    public override string ToString() => $"{FirstName} {LastName}";
}