using eShop.Catalog.Domain.Brands;
using eShop.Catalog.Domain.Brands.Queries.GetById;
using Ilse.Cqrs.Queries;

namespace eShop.Catalog.Application.Brands.Queries.GetById;

public class AppGetBrandByIdQueryHandler(
    IQueryDispatcher queryDispatcher): IQueryHandler<AppGetBrandByIdQuery, Brand>
{
    public async Task<Brand> HandleAsync(AppGetBrandByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var getBrandByIdQuery = new GetBrandByIdQuery(query.Id);
        return await queryDispatcher.QueryAsync<GetBrandByIdQuery, Brand>(getBrandByIdQuery, cancellationToken);
    }
}