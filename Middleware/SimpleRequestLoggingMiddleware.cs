public class SimpleRequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<SimpleRequestLoggingMiddleware> _logger;

    public SimpleRequestLoggingMiddleware(RequestDelegate next, ILogger<SimpleRequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var method = context.Request.Method;
        var path = context.Request.Path;

        await _next(context); // Proceed to next middleware

        var statusCode = context.Response.StatusCode;

        _logger.LogInformation("HTTP {Method} {Path} responded {StatusCode}", method, path, statusCode);
    }
}
