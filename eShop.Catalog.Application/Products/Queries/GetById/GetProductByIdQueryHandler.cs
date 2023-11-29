using eShop.Catalog.Domain.Products;
using eShop.Catalog.Domain.Products.Queries.GetById;
using Ilse.Cqrs.Queries;

namespace eShop.Catalog.Application.Products.Queries.GetById;

public class GetProductByIdQueryHandler(
    IQueryDispatcher queryDispatcher): IQueryHandler<AppGetProductByIdQuery, Product>
{
    public async Task<Product> HandleAsync(AppGetProductByIdQuery query, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        return await 
            queryDispatcher.QueryAsync<GetProductByIdQuery, Product>(new GetProductByIdQuery(query.Id), cancellationToken);
    }
}
