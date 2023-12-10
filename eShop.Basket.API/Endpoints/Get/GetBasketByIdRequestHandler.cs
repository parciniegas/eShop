using eShop.Basket.Application.Cart.Queries;
using eShop.Common.Exceptions;
using Ilse.Cqrs.Queries;
using Ilse.MinimalApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace eShop.Basket.API.Endpoints.Get;

public class GetBasketByIdRequestHandler: IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/baskets/{basketId}", HandleAsync)
            .WithTags("Baskets");
    }

    private static async Task<Results<Ok<Basket.Domain.Cart.Basket>, BadRequest<string>>> HandleAsync(IQueryDispatcher queryDispatcher,
        string basketId)
    {
        try
        {
            var result = await queryDispatcher.QueryAsync<AppGetBasketByIdQuery, Basket.Domain.Cart.Basket>(
                new AppGetBasketByIdQuery(basketId));
            return TypedResults.Ok(result);
        }
        catch (EntityNotFoundException e)
        {
            return TypedResults.BadRequest(e.Message);
        }
    }   
}