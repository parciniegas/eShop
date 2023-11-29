using eShop.Catalog.Domain.Brands.Queries.GetAll;
using Ilse.Cqrs.Queries;

namespace eShop.Catalog.Application.Brands.Queries.GetAll;

public class AppGetAllBrandsQueryHandler(
    IQueryDispatcher queryDispatcher): IQueryHandler<AppGetAllBrandsQueryResult>
{
    public async Task<AppGetAllBrandsQueryResult> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var brands = await queryDispatcher.QueryAsync<GetAllBrandsQueryResult>(cancellationToken);
        return new AppGetAllBrandsQueryResult(brands.Brands);
    }
}