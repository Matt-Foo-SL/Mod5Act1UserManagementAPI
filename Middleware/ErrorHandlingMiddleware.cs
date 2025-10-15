using System.Text.Json;
public class ErrorHandlingMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ErrorHandlingMiddleware> _logger;

	public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context); // Proceed to next middleware
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Unhandled exception occurred.");

			context.Response.StatusCode = StatusCodes.Status500InternalServerError;
			context.Response.ContentType = "application/json";

			var errorResponse = new { error = "Internal server error." };
			var json = JsonSerializer.Serialize(errorResponse);

			await context.Response.WriteAsync(json);
		}
	}
}