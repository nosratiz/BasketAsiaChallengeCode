using Ardalis.GuardClauses;
using Mc2.CrudTest.Domain.Exceptions;
using Mc2.CrudTest.Domain.Validators;
using PhoneNumbers;

namespace Mc2.CrudTest.Domain.Extensions;

public static class PhoneNumberGuards
{
    public static void InvalidPhoneNumber(this IGuardClause guardClause, string phoneNumber)
    {
        if (MobileValidator.IsValid(phoneNumber) == false)
            throw new InvalidPhoneNumberExceptions(phoneNumber);
    }
}