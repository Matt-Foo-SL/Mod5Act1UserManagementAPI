var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();


var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<TokenValidationMiddleware>();
app.UseMiddleware<SimpleRequestLoggingMiddleware>();
app.MapControllers();

app.Run();
