using eShop.Catalog.Application.Products.Commands.Update;

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
        UpdateProductRequest request,
        string id)
    {
        logger.LogTrace("UpdateProductRequestHandler.HandleAsync called with id: {id} and {request}", 
            id, request);
        await commandDispatcher.ExecAsync(new AppProductUpdateCommand(id, request.Name, request.Description,
            request.BrandId));
    }
}