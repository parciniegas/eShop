namespace eShop.Catalog.API.Middleware;

public class LoggingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, ILogger<LoggingMiddleware> logger)
    {
        logger.LogInformation("LoggingMiddleware: Start");
        await next(context);
        logger.LogInformation("LoggingMiddleware: End");
    }
}