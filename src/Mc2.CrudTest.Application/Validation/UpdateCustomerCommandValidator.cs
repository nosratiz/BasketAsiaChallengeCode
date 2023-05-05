using FluentValidation;
using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Application.Customers.Command.Update;
using Microsoft.EntityFrameworkCore;
using PhoneNumbers;

namespace Mc2.CrudTest.Application.Validation;

public sealed class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    private readonly IMcTestContext _context;
    public UpdateCustomerCommandValidator(IMcTestContext context)
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
            .MaximumLength(254);

        RuleFor(x => x.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(20);

        RuleFor(x => x.BankAccountNumber)
            .NotNull()
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(18);

        RuleFor(x => x.DateOfBirth).NotNull().NotEmpty();

        RuleFor(x => x)
            .MustAsync(BeUniqueCustomer)
            .WithMessage("The specified customer already exists.")
            .MustAsync(BeUniqueEmail)
            .WithMessage("The specified email already exists.")
            .MustAsync(BeUniqueBankAccountNumber)
            .WithMessage("The specified bank account number already exists.")
            .MustAsync(BeUniquePhoneNumber)
            .WithMessage("The specified phone number already exists.");


    }

    private async Task<bool> BeUniqueCustomer(UpdateCustomerCommand model, CancellationToken cancellationToken)
        => !await _context
        .Customers
        .AnyAsync(x => x.FirstName == model.FirstName
        && x.LastName == model.LastName
         && x.DateOfBirth == model.DateOfBirth
         && x.Id != model.Id
         , cancellationToken);


    private async Task<bool> BeUniqueEmail(UpdateCustomerCommand model, CancellationToken cancellationToken)
        => !await _context
        .Customers
        .AnyAsync(x => x.Email.Value == model.Email && x.Id != model.Id, cancellationToken);


    private async Task<bool> BeUniqueBankAccountNumber(UpdateCustomerCommand model, CancellationToken cancellationToken)
        => !await _context
        .Customers
        .AnyAsync(x => x.BankAccountNumber == model.BankAccountNumber && x.Id != model.Id, cancellationToken);


    private async Task<bool> BeUniquePhoneNumber(UpdateCustomerCommand model, CancellationToken cancellationToken)
        => !await _context
        .Customers
        .AnyAsync(x => x.PhoneNumber.Value == model.PhoneNumber && x.Id != model.Id, cancellationToken);
    
    
    private bool CheckPhoneNumber(string phoneNumber)
    {
        PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance(); 
        
        try
        {
            var number = phoneUtil.Parse(phoneNumber, "US");
            return phoneUtil.IsValidNumber(number);
        }
        catch (NumberParseException)
        {
            return false;
        }
    }
}