using eShop.Catalog.Domain.Brands;
using eShop.Catalog.Domain.Brands.Queries.GetById;
using eShop.Catalog.Domain.Exceptions;
using Ilse.Cqrs.Queries;
using Ilse.MinimalApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace eShop.Catalog.API.Endpoints.Brands.Get;

public class GetBrandByIdRequestHandler: IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/brands/{id:int}", HandleAsync)
            .RequireAuthorization("catalog.read")
            .WithTags("Brands");
    }

    private static async Task<Results<Ok<GetBrandRequestResult>, BadRequest<string>>> 
        HandleAsync(IQueryDispatcher commandDispatcher, int id)
    {
        try
        {
            var brand = await commandDispatcher.QueryAsync<GetBrandByIdQuery, Brand>(new GetBrandByIdQuery(id));
            var getBrandRequestResult = new GetBrandRequestResult(brand.Id, brand.Name, brand.Description);
            return TypedResults.Ok(getBrandRequestResult);
        }
        catch (EntityNotFoundException e)
        {
            return TypedResults.BadRequest(e.Message);
        }
    }
}