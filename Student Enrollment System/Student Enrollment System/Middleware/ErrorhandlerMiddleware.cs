using System.Net;

namespace Student_Enrollment_System.Middleware;

public class ErrorhandlerMiddleware
{
    private readonly ILogger<ErrorhandlerMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ErrorhandlerMiddleware(ILogger<ErrorhandlerMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            var errorId = Guid.NewGuid();
            // log This exception
            _logger.LogError(ex, $"{errorId} : {ex.Message}");

            // Custom Error Responce
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var error = new
            {
                Id = errorId,
                ErroMessage = "Something went wrong! we are looking into Resolving this."
            };

            await httpContext.Response.WriteAsJsonAsync(error);
        }
    }
}
