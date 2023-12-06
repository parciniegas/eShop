using eShop.Catalog.Domain.Baskets;
using eShop.Catalog.Domain.Baskets.Queries;
using Ilse.Cqrs.Queries;

namespace eShop.Catalog.Application.Baskets.Queries;

public class AppGetBasketByIdQueryHandler(
    IQueryDispatcher queryDispatcher): IQueryHandler<AppGetBasketByIdQuery, Basket>
{
    public async Task<Basket> HandleAsync(AppGetBasketByIdQuery query, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        return await queryDispatcher.QueryAsync<GetBasketByIdQuery, Basket>
            (new GetBasketByIdQuery(query.BuyerId), cancellationToken);
    }
}