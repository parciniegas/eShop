using eShop.Catalog.Application.Baskets.Commands.Delete;

namespace eShop.Catalog.API.Endpoints.Baskets.Delete;

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