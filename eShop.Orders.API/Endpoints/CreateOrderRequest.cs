using eShop.Orders.Application.Commands;
using Ilse.Cqrs.Commands;
using Ilse.MinimalApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace eShop.Orders.API.Endpoints;

public class CreateOrderRequestHandler : IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/orders", HandleAsync)
            .WithTags("Orders");
    }

    private static async Task<Results<Created<string>, BadRequest<string>>> HandleAsync(
        ICommandDispatcher dispatcher,
        AppCreateOrderCommand command)
    {
        var result = await dispatcher.ExecAsync<AppCreateOrderCommand, string>(command) 
                     ?? throw new InvalidOperationException();
        return TypedResults.Created($"/orders/{result}", result);
    }
}