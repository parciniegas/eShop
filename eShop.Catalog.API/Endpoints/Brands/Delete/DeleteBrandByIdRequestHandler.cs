using eShop.Catalog.Application.Brands.Commands.Delete;
using eShop.Catalog.Domain.Exceptions;
using Ilse.Cqrs.Commands;
using Ilse.MinimalApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace eShop.Catalog.API.Endpoints.Brands.Delete;

public class DeleteBrandByIdRequestHandler: IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        // ReSharper disable once RouteTemplates.RouteParameterConstraintNotResolved
        endpoints.MapDelete("/brands/{id:int}", HandleAsync)
            .RequireAuthorization("catalog.delete")
            .WithTags("Brands");
    }

    private static async Task<Results<Ok,BadRequest<string>>> 
        HandleAsync(ICommandDispatcher commandDispatcher, int id)
    {
        try
        {
            await commandDispatcher.ExecAsync(new AppDeleteBrandCommand(id));
            return TypedResults.Ok();
        }
        catch (EntityNotFoundException e)
        {
            return TypedResults.BadRequest(e.Message);
        }
    }
}