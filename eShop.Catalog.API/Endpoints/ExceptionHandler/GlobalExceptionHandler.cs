using Ilse.CorrelationId.Context;
using Ilse.MinimalApi;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Catalog.API.Endpoints.ExceptionHandler;

public class GlobalExceptionHandler : IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.Map("/error", HandleAsync);
    }

    private static async Task HandleAsync(HttpContext context,
        ILogger<GlobalExceptionHandler> logger)
    {
        var ca = context.RequestServices.GetService<ICorrelationContextAccessor>();
        var correlationId = ca?.CorrelationContext?.CorrelationId ?? context.TraceIdentifier;
        var exceptionHandler =
            context.Features.Get<IExceptionHandlerPathFeature>();
        context.Response.ContentType = "application/json";
        var details = new ProblemDetails
        {
            Detail = exceptionHandler?.Error.Message,
            Extensions =
            {
                ["traceId"] = System.Diagnostics.Activity.Current?.Id ?? context.TraceIdentifier,
                ["correlationId"] = correlationId
            },
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Status = StatusCodes.Status500InternalServerError
        };

        logger.LogError(exceptionHandler?.Error, exceptionHandler?.Error.Message);
        await context.Response.WriteAsync(
            System.Text.Json.JsonSerializer.Serialize(details));
    }
}