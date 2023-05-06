using PhoneNumbers;

namespace Mc2.CrudTest.Domain.Validators;

public static class MobileValidator
{
    public static bool IsValid(string phoneNumber)
    {
        PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance(); 
        
        try
        {
            var number = phoneUtil.Parse(phoneNumber, null);
            var phoneNumberType = phoneUtil.GetNumberType(number);

            if (phoneNumberType == PhoneNumberType.MOBILE)
                return true;

            return false;
        }
        catch (NumberParseException)
        {
            return false;
        }
    }
}