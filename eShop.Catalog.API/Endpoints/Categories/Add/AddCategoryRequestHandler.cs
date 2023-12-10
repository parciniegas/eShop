using eShop.Catalog.Application.Categories.Commands;
using eShop.Common.Exceptions;

namespace eShop.Catalog.API.Endpoints.Categories.Add;

public class AddCategoryRequestHandler: IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/categories", HandleAsync)
            .RequireAuthorization("catalog.write")
            .WithTags("Categories");
    }

    private static async Task<Results<Created<AppAddCategoryCommandResult>, BadRequest<string>>> 
        HandleAsync(ICommandDispatcher commandDispatcher, AddCategoryRequest request)
    {
        try
        {
            var command = new AppAddCategoryCommand(request.Name, request.Description);
            var result = await commandDispatcher.ExecAsync<AppAddCategoryCommand, AppAddCategoryCommandResult>(command);
            var addCategoryRequestResult = new AddCategoryRequestResult(result.Id);
            return TypedResults.Created($"/categories/{addCategoryRequestResult.Id}", result);
        }
        catch (EntityAlreadyExistsException e)
        {
            return TypedResults.BadRequest(e.Message);
        }
    }
}