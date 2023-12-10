using eShop.Basket.Application.Cart.Commands.Add;
using Ilse.Cqrs.Commands;
using Ilse.MinimalApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace eShop.Basket.API.Endpoints.Add;

public class AddItemToBasketRequestHandler: IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/baskets/{basketId}/items/add", HandleAsync)
            .WithTags("Baskets");
    }

    private static async Task<Ok<Domain.Cart.Basket>> HandleAsync(
        ICommandDispatcher commandDispatcher,
        string basketId,
        AddItemToBasketRequest request)
    {
        var basket = await commandDispatcher.ExecAsync<AppAddItemToBasketCommand, Domain.Cart.Basket>
        (new AppAddItemToBasketCommand(basketId, request.ProductId,
            request.ProductName, request.Quantity, request.UnitPrice));
        return TypedResults.Ok(basket);
    }
}