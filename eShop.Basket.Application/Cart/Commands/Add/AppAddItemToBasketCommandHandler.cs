using eShop.Basket.Domain.Cart.Commands.Add;
using Ilse.Cqrs.Commands;

namespace eShop.Basket.Application.Cart.Commands.Add;

public class AppAddItemToBasketCommandHandler(
    ICommandDispatcher commandDispatcher): ICommandHandler<AppAddItemToBasketCommand, Domain.Cart.Basket>
{
    public async Task<Domain.Cart.Basket> HandleAsync(AppAddItemToBasketCommand command, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        return await commandDispatcher.ExecAsync<AddItemToBasketCommand, Domain.Cart.Basket>
            (new AddItemToBasketCommand(command.BuyerId, command.ProductId, command.ProductName, 
                command.Quantity, command.UnitPrice), cancellationToken);
    }
}