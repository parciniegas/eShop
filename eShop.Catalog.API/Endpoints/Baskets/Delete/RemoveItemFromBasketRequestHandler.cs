using eShop.Catalog.Application.Baskets.Commands.Delete;

namespace eShop.Catalog.API.Endpoints.Baskets.Delete;

public class RemoveItemFromBasketRequestHandler: IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/baskets/{basketId}/items/remove", HandleAsync)
            .WithTags("Baskets");
    }

    private static async Task<Results<Ok<Basket>, BadRequest<string>>> HandleAsync(
        ICommandDispatcher commandDispatcher, 
        RemoveItemFromBasketRequest request,
        string basketId)
    {
        try
        {
            var basket = await commandDispatcher.ExecAsync<AppRemoveItemFromBasketCommand, Basket>(new AppRemoveItemFromBasketCommand(basketId, request.ProductId, 
                request.Quantity));
            return TypedResults.Ok(basket);
        }
        catch (EntityNotFoundException e)
        {
            return TypedResults.BadRequest(e.Message);
        }
    }
}