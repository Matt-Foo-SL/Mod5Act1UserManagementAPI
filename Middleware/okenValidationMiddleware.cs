public class TokenValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<TokenValidationMiddleware> _logger;

    public TokenValidationMiddleware(RequestDelegate next, ILogger<TokenValidationMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].ToString();

        if (string.IsNullOrEmpty(token) || !IsValidToken(token))
        {
            _logger.LogWarning("Unauthorized request: missing or invalid token.");
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized: Invalid or missing token.");
            return;
        }

        await _next(context);
    }

    private bool IsValidToken(string token)
    {
        // Example: check for a static token (replace with real validation logic)
        const string validToken = "Bearer my-secret-token";
        return token == validToken;
    }
}