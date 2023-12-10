using eShop.Basket.Application.Cart.Commands.Delete;
using eShop.Common.Exceptions;
using Ilse.Cqrs.Commands;
using Ilse.MinimalApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace eShop.Basket.API.Endpoints.Delete;


public class RemoveBasketRequestHandler: IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapDelete("/baskets/{basketId}", HandleAsync)
            .WithTags("Baskets");
    }

    private async Task<Results<Ok, BadRequest<string>>> HandleAsync(
        ICommandDispatcher commandDispatcher,
        string basketId)
    {
        try
        {
            await commandDispatcher.ExecAsync(new AppRemoveBasketCommand(basketId));
            return TypedResults.Ok();
        }
        catch (EntityNotFoundException e)
        {
            return TypedResults.BadRequest(e.Message);
        }
    }
}