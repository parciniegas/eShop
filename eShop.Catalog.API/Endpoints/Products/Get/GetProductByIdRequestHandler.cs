using eShop.Catalog.Application.Products.Queries.GetById;
using eShop.Catalog.Domain.Products;
using eShop.Common.Exceptions;

namespace eShop.Catalog.API.Endpoints.Products.Get;

public class GetProductByIdRequestHandler: IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/products/{id}", HandleAsync)
            .RequireAuthorization("catalog.read")
            .WithTags("Products");
    }

    private static async Task<Results<Ok<Product>, BadRequest<string>>> 
        HandleAsync(IQueryDispatcher queryDispatcher,
            ILogger<GetProductByIdRequestHandler> logger,
            string id)
    {
        try
        {
            var product = await 
                queryDispatcher.QueryAsync<AppGetProductByIdQuery, Product>(new AppGetProductByIdQuery(id));
            return TypedResults.Ok(product);
        }
        catch (EntityNotFoundException e)
        {
            return TypedResults.BadRequest(e.Message);
        }
    }
}