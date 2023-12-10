using eShop.Basket.Domain.Cart.Queries;
using Ilse.Cqrs.Queries;

namespace eShop.Basket.Application.Cart.Queries;

public class AppGetBasketByIdQueryHandler(
    IQueryDispatcher queryDispatcher): IQueryHandler<AppGetBasketByIdQuery, Domain.Cart.Basket>
{
    public async Task<Domain.Cart.Basket> HandleAsync(AppGetBasketByIdQuery query, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        return await queryDispatcher.QueryAsync<GetBasketByIdQuery, Domain.Cart.Basket>
            (new GetBasketByIdQuery(query.BuyerId), cancellationToken);
    }
}