namespace Mc2.CrudTest.Application.Common.Helper;

public class ApiMessage
{
    public ApiMessage()
    {
    }

    public ApiMessage(int code, string message)
    {
        Code = code;
        Message = message;
    }

    public int Code { get; set; }
    public string Message { get; set; } = null!;
}