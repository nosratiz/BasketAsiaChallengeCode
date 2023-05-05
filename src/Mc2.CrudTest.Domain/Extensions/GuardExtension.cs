using Ardalis.GuardClauses;
using Mc2.CrudTest.Domain.Exceptions;
using PhoneNumbers;

namespace Mc2.CrudTest.Domain.Extensions;

public static class PhoneNumberGuards
{
    public static void InvalidPhoneNumber(this IGuardClause guardClause, string phoneNumber)
    {
        PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
        
        var number = phoneUtil.Parse(phoneNumber, "US");

        if (phoneUtil.IsValidNumber(number) == false)
            throw new InvalidPhoneNumberExceptions(phoneNumber);
        
    }
}