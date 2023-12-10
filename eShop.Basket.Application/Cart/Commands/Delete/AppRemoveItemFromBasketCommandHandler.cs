using eShop.Basket.Domain.Cart.Commands.Delete;
using Ilse.Cqrs.Commands;

namespace eShop.Basket.Application.Cart.Commands.Delete;

public class AppRemoveItemFromBasketCommandHandler(
    ICommandDispatcher commandDispatcher): ICommandHandler<AppRemoveItemFromBasketCommand, Basket.Domain.Cart.Basket>
{
    public async Task<Domain.Cart.Basket> HandleAsync(AppRemoveItemFromBasketCommand command, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        return await commandDispatcher.ExecAsync<RemoveItemFromBasketCommand, Domain.Cart.Basket>(new RemoveItemFromBasketCommand(command.BuyerId, command.ProductId, 
            command.Quantity), cancellationToken);
    }
}