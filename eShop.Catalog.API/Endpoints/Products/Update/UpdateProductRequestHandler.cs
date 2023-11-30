using eShop.Catalog.Domain.Products;
using Ilse.Cqrs.Commands;
using Ilse.MinimalApi;
using Microsoft.AspNetCore.JsonPatch;

namespace eShop.Catalog.API.Endpoints.Products.Update;

public class UpdateProductRequestHandler: IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPatch("/products/{id}", HandleAsync)
            .WithTags("Products");
    }

    private static async Task HandleAsync(HttpContext context,
        ICommandDispatcher commandDispatcher,
        ILogger<UpdateProductRequestHandler> logger,
        JsonPatchDocument<Product> request)
    {
        await Task.CompletedTask;
    }
}