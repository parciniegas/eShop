using eShop.Catalog.Domain.Exceptions;
using Ilse.Cqrs.Commands;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Baskets.Commands.Delete;

public class RemoveBasketCommandHandler(IRepository repository): ICommandHandler<RemoveBasketCommand>
{
    public async Task HandleAsync(RemoveBasketCommand command, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        var basket = await repository.GetByIdAsync<Basket, string>(command.BuyerId, cancellationToken);
        if (basket == null)
            throw new EntityNotFoundException($"Basket with id '{command.BuyerId}' not found!");
        await repository.DeleteAsync(basket, cancellationToken);
    }
}