using eShop.Catalog.Application.Baskets.Commands.Add;

namespace eShop.Catalog.API.Endpoints.Baskets.Add;

public class AddItemToBasketRequestHandler: IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/baskets/{basketId}/items/add", HandleAsync)
            .WithTags("Baskets");
    }

    private static async Task<Ok<Basket>> HandleAsync(
        ICommandDispatcher commandDispatcher,
        string basketId,
        AddItemToBasketRequest request)
    {
        var basket = await commandDispatcher.ExecAsync<AppAddItemToBasketCommand, Basket>
            (new AppAddItemToBasketCommand(basketId, request.ProductId,
                request.ProductName, request.Quantity, request.UnitPrice));
        return TypedResults.Ok(basket);
    }
}