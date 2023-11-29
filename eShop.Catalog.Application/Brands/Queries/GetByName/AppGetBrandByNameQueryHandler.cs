using eShop.Catalog.Domain.Brands;
using eShop.Catalog.Domain.Brands.Queries.GetByName;
using Ilse.Cqrs.Queries;

namespace eShop.Catalog.Application.Brands.Queries.GetByName;

public class AppGetBrandByNameQueryHandler(
    IQueryDispatcher queryDispatcher): IQueryHandler<GetBrandByNameQuery, Brand>
{
    public async Task<Brand> HandleAsync(GetBrandByNameQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        return await queryDispatcher.QueryAsync<GetBrandByNameQuery, Brand>(new GetBrandByNameQuery(query.Name));
    }
}