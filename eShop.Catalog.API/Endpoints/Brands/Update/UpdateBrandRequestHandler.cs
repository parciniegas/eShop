using eShop.Catalog.Application.Brands.Commands.Update;

namespace eShop.Catalog.API.Endpoints.Brands.Update;

public class UpdateBrandRequestHandler: IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPut("/brands/{id}", HandleAsync)
            .RequireAuthorization("catalog.update")
            .WithTags("Brands");
    }

    private static async Task<Results<Accepted, BadRequest<string>>> HandleAsync(
        UpdateBrandRequest request,
        ICommandDispatcher commandDispatcher, int id)
    {
        var command = new AppUpdateBrandCommand(id, request.Name, request.Description);
        await commandDispatcher.ExecAsync(command);
        return TypedResults.Accepted($"/brands/{id}");
    }
}