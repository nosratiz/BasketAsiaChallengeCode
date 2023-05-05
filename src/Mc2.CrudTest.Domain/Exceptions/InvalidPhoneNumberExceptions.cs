namespace Mc2.CrudTest.Domain.Exceptions;

public sealed class InvalidPhoneNumberExceptions : Exception
{
    public InvalidPhoneNumberExceptions(string value) : base($"Invalid phone number {value}")
    {
    }
}