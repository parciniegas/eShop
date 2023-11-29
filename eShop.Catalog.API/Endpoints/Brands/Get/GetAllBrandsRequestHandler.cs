using eShop.Catalog.Application.Brands.Queries.GetAll;
using Ilse.Cqrs.Queries;
using Ilse.MinimalApi;

namespace eShop.Catalog.API.Endpoints.Brands.Get;

public class GetAllBrandsRequestHandler: IEndpoint
{
    public void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/brands", HandleAsync)
            .RequireAuthorization("catalog.read")
            .WithTags("Brands");
    }

    private static async Task<List<GetBrandRequestResult>> HandleAsync(
        ILogger<GetAllBrandsRequestHandler> logger,
        IQueryDispatcher queryDispatcher)
    {
        logger.LogTrace("GetAllBrands.HandleAsync");
        return (await queryDispatcher.QueryAsync<AppGetAllBrandsQueryResult>())
            .Brands 
            .Select(b => new GetBrandRequestResult(b.Id, b.Name, b.Description))
            .ToList();
    }
}