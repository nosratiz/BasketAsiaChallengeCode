using Mc2.CrudTest.Domain.Helper;

namespace Mc2.CrudTest.Domain.Exceptions;

public class BusinessException : Exception
{
    public List<ApiMessage> Errors { get; set; }

    public BusinessException()
    {
    }

    public BusinessException(List<ApiMessage> errors)
    {
        Errors = errors;
    }

    public BusinessException(string message) : base(message)
    {
    }

    public BusinessException(string message, Exception innerException) : base(message, innerException)
    {
    }
}



