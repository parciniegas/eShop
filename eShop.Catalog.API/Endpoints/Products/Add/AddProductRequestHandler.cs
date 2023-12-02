using eShop.Catalog.Application.Products.Commands.Add;
using DomainCommandTag = eShop.Catalog.Application.Products.Commands.Add.CommandTag;

namespace eShop.Catalog.API.Endpoints.Products.Add;

public class AddProductRequestHandler: IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/products", HandleAsync)
            .RequireAuthorization("catalog.write")
            .WithTags("Products");
    }

    private static async Task<Results<Created<AddProductRequestResult>,
            ValidationProblem,
            BadRequest<string>>> 
        HandleAsync(IValidator<AddProductRequest> validator, 
            ICommandDispatcher commandDispatcher,
            ILogger<AddProductRequestHandler> logger,
            AddProductRequest request)
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.ToDictionary();
            logger.LogWarning("AddProductRequestHandler: ValidationProblem {@errors}", errors);
            return TypedResults.ValidationProblem(errors);
        }
        try
        {
            logger.LogTrace("Creating product with data {request}", request);
            var command = new AppAddProductCommand(request.Id, request.Name, request.Description, request.BrandId,
                request.Price, request.AvailableStock, request.RestockThreshold, request.Labels,
                request.Tags.Select(t => new DomainCommandTag(t.Name, t.Value)).ToList(),
                request.CategoryIds);
            await commandDispatcher.ExecAsync(command);
            return TypedResults.Created("", new AddProductRequestResult(command.Id));
        }
        catch (EntityAlreadyExistsException e)
        {
            logger.LogError(e.Message);
            return TypedResults.BadRequest(e.Message);
        }
    }
}