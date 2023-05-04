namespace Mc2.CrudTest.Application.Common.Helper;

public class ApiMessage
{
    public ApiMessage()
    {
    }

    public ApiMessage(string message) => Message = message;

    public string Message { get; set; } = null!;

}