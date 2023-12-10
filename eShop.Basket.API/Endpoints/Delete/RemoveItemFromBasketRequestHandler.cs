using eShop.Basket.Application.Cart.Commands.Delete;
using eShop.Common.Exceptions;
using Ilse.Cqrs.Commands;
using Ilse.MinimalApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace eShop.Basket.API.Endpoints.Delete;

public class RemoveItemFromBasketRequestHandler: IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/baskets/{basketId}/items/remove", HandleAsync)
            .WithTags("Baskets");
    }

    private static async Task<Results<Ok<Basket.Domain.Cart.Basket>, BadRequest<string>>> HandleAsync(
        ICommandDispatcher commandDispatcher, 
        RemoveItemFromBasketRequest request,
        string basketId)
    {
        try
        {
            var basket = await commandDispatcher.ExecAsync<AppRemoveItemFromBasketCommand, Basket.Domain.Cart.Basket>(new AppRemoveItemFromBasketCommand(basketId, request.ProductId, 
                request.Quantity));
            return TypedResults.Ok(basket);
        }
        catch (EntityNotFoundException e)
        {
            return TypedResults.BadRequest(e.Message);
        }
    }
}