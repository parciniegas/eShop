using eShop.Catalog.Domain.Baskets;
using eShop.Catalog.Domain.Baskets.Commands.Delete;
using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Application.Baskets.Commands.Delete;

public class AppRemoveItemFromBasketCommandHandler(
    ICommandDispatcher commandDispatcher): ICommandHandler<AppRemoveItemFromBasketCommand, Basket>
{
    public async Task<Basket> HandleAsync(AppRemoveItemFromBasketCommand command, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        return await commandDispatcher.ExecAsync<RemoveItemFromBasketCommand, Basket>(new RemoveItemFromBasketCommand(command.BuyerId, command.ProductId, 
            command.Quantity), cancellationToken);
    }
}