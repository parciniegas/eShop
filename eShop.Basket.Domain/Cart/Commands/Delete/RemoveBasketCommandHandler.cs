using eShop.Common.Exceptions;
using Ilse.Cqrs.Commands;

namespace eShop.Basket.Domain.Cart.Commands.Delete;

public class RemoveBasketCommandHandler(IBasketRepository repository): ICommandHandler<RemoveBasketCommand>
{
    public async Task HandleAsync(RemoveBasketCommand command, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        var basket = await repository.GetBasketAsync(command.BuyerId, cancellationToken);
        if (basket == null)
            throw new EntityNotFoundException($"Basket with id '{command.BuyerId}' not found!");
        await repository.DeleteBasketAsync(basket.BuyerId, cancellationToken);
    }
}