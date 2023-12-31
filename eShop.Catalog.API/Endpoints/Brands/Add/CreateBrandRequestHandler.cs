using eShop.Common.Exceptions;

namespace eShop.Catalog.API.Endpoints.Brands.Add;

public class CreateBrandRequestHandler: IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/brands", HandleAsync)
            .RequireAuthorization("catalog.admin")
            .WithTags("Brands");
    }
    
    private static async Task<Results<Created<AppAddBrandCommandResult>, BadRequest<string>>> 
        HandleAsync(AppAddBrandCommand command, ICommandDispatcher commandDispatcher)
    {
        try
        {
            var result = await commandDispatcher.ExecAsync<AppAddBrandCommand, AppAddBrandCommandResult>(command);
            return TypedResults.Created($"/brands/{result.Id}", result);
        }
        catch (EntityAlreadyExistsException e)
        {
            return TypedResults.BadRequest(e.Message);
        }
    }
}