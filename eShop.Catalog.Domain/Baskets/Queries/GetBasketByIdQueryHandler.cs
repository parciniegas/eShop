using eShop.Catalog.Domain.Exceptions;
using Ilse.Cqrs.Queries;

namespace eShop.Catalog.Domain.Baskets.Queries;

public class GetBasketByIdQueryHandler(
    IBasketRepository repository): IQueryHandler<GetBasketByIdQuery, Basket>
{
    public async Task<Basket> HandleAsync(GetBasketByIdQuery query, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        var basket = await repository.GetBasketAsync(query.Id, cancellationToken);
        if (basket == null)
            throw new EntityNotFoundException($"Basket with id '{query.Id}' not found!");
        return basket;
    }
}