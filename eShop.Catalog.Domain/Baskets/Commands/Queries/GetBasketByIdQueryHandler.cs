using eShop.Catalog.Domain.Exceptions;
using Ilse.Cqrs.Queries;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Baskets.Commands.Queries;

public class GetBasketByIdQueryHandler(
    IRepository repository): IQueryHandler<GetBasketByIdQuery, Basket>
{
    public async Task<Basket> HandleAsync(GetBasketByIdQuery query, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        var basket = await repository.GetByIdAsync<Basket, string>(query.Id, cancellationToken);
        if (basket == null)
            throw new EntityNotFoundException($"Basket with id '{query.Id}' not found!");
        return basket;
    }
}