using eShop.Catalog.Domain.Brands;
using eShop.Catalog.Domain.Brands.Queries.GetByName;

namespace eShop.Catalog.API.Endpoints.Brands.Get;

public class GetBrandByNameRequestHandler: IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/brands/by_name/{name}", HandleAsync)
            .RequireAuthorization("catalog.read")
            .WithTags("Brands");
    }

    private static async Task<Results<Ok<GetBrandRequestResult>, BadRequest<string>>> 
        HandleAsync(IQueryDispatcher queryDispatcher, string name)
    {
        try
        {
            var brand = await queryDispatcher.QueryAsync<GetBrandByNameQuery, Brand>(new GetBrandByNameQuery(name));
            var plainBrand = new GetBrandRequestResult(brand.Id, brand.Name, brand.Description);
            return TypedResults.Ok(plainBrand);
        }
        catch (EntityNotFoundException e)
        {
            return TypedResults.BadRequest(e.Message);
        }
    }
}

