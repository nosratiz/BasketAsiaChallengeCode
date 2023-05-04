using System.Net;
using System.Text.Json;
using Mc2.CrudTest.Domain.Exceptions;

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
                ValidationException
                 =>
                    (int)HttpStatusCode.BadRequest,
                CustomerNotFoundException =>
                    (int)HttpStatusCode.NotFound,
                UnauthorizedAccessException =>
                    (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var result = JsonSerializer.Serialize(new { error?.Message });

            await response.WriteAsync(result);
        }
    }
}