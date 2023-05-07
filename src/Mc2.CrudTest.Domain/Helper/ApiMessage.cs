namespace Mc2.CrudTest.Domain.Helper;

public sealed class ApiMessage
{
    public ApiMessage()
    {
    }

    public ApiMessage(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; set; }
    public string Message { get; set; } = null!;
}