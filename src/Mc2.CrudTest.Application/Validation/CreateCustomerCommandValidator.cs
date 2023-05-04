using FluentValidation;
using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Application.Customers.Command.Create;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Application.Validation;

public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    private readonly IMcTestContext _context;

    public CreateCustomerCommandValidator(IMcTestContext context)
    {
        _context = context;

        RuleFor(x => x.FirstName)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);

        RuleFor(x => x.LastName)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(150);

        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .MinimumLength(5)
            .MaximumLength(254)
            .MustAsync(BeUniqueEmail)
            .WithMessage("The specified email already exists.");

        RuleFor(x => x.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(20)
            .MustAsync(BeUniquePhoneNumber)
            .WithMessage("The specified phone number already exists.");

        RuleFor(x => x.BankAccountNumber)
            .NotNull()
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(18)
            .MustAsync(BeUniqueBankAccountNumber)
            .WithMessage("The specified bank account number already exists.");

        RuleFor(x => x.DateOfBirth).NotNull().NotEmpty();

        RuleFor(x => x)
            .MustAsync(BeUniqueCustomer)
            .WithMessage("The specified customer already exists.");
    }

    private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        => !await _context
            .Customers
            .AnyAsync(x => x.Email == email, cancellationToken);

    private async Task<bool> BeUniqueCustomer(CreateCustomerCommand model, CancellationToken cancellationToken)
        => !await _context
            .Customers
            .AnyAsync(x => x.FirstName == model.FirstName
                           && x.LastName == model.LastName
                           && x.DateOfBirth == model.DateOfBirth
                , cancellationToken);


    private async Task<bool> BeUniqueBankAccountNumber(string bankAccountNumber, CancellationToken cancellationToken)
        => !await _context
            .Customers
            .AnyAsync(x => x.BankAccountNumber == bankAccountNumber, cancellationToken);


    private async Task<bool> BeUniquePhoneNumber(string phoneNumber, CancellationToken cancellationToken)
        => !await _context
            .Customers
            .AnyAsync(x => x.PhoneNumber == phoneNumber, cancellationToken);


   
}