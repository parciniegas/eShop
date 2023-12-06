using eShop.Catalog.Domain.Baskets;
using eShop.Catalog.Domain.Baskets.Commands.Add;
using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Application.Baskets.Commands.Add;

public class AppAddItemToBasketCommandHandler(
    ICommandDispatcher commandDispatcher): ICommandHandler<AppAddItemToBasketCommand, Basket>
{
    public async Task<Basket> HandleAsync(AppAddItemToBasketCommand command, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        return await commandDispatcher.ExecAsync<AddItemToBasketCommand, Basket>
            (new AddItemToBasketCommand(command.BuyerId, command.ProductId, command.ProductName, 
                command.Quantity, command.UnitPrice), cancellationToken);
    }
}