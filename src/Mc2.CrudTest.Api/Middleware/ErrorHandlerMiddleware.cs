using System.Net;
using FluentValidation;
using Mc2.CrudTest.Domain.Exceptions;
using Mc2.CrudTest.Domain.Helper;
using Newtonsoft.Json;

namespace Mc2.CrudTest.Api.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            
            var response = context.Response;
            response.ContentType = "application/json";

            _logger.LogError(error, error.Message, error.StackTrace);

            response.StatusCode = error switch
            {
                BusinessException
                    =>
                    (int) HttpStatusCode.BadRequest,
                ValidationException =>
                    (int) HttpStatusCode.BadRequest,
                CustomerNotFoundException =>
                    (int) HttpStatusCode.NotFound,
                UnauthorizedAccessException =>
                    (int) HttpStatusCode.Unauthorized,
                _ => (int) HttpStatusCode.InternalServerError
            };
            
            // it just for perpouse of this test
            
            var result = error is BusinessException ?
                JsonConvert.SerializeObject(error.GetType()
                    .GetProperty("Errors")?
                    .GetValue(error, null)) 
                :JsonConvert.SerializeObject(new ApiMessage {Message = error.Message});
            
            _logger.LogInformation(result);

            await response.WriteAsync(result);
        }
    }
}