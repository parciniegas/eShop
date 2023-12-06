using eShop.Catalog.Application.Baskets.Queries;

namespace eShop.Catalog.API.Endpoints.Baskets.Get;

public class GetBasketByIdRequestHandler: IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/baskets/{basketId}", HandleAsync)
            .WithTags("Baskets");
    }

    private static async Task<Results<Ok<Basket>, BadRequest<string>>> HandleAsync(IQueryDispatcher queryDispatcher,
        string basketId)
    {
        try
        {
            var result = await queryDispatcher.QueryAsync<AppGetBasketByIdQuery, Basket>(
                new AppGetBasketByIdQuery(basketId));
            return TypedResults.Ok(result);
        }
        catch (EntityNotFoundException e)
        {
            return TypedResults.BadRequest(e.Message);
        }
    }   
}