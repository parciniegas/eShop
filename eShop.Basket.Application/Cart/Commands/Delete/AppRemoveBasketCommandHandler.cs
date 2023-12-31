using eShop.Basket.Domain.Cart.Commands.Delete;
using Ilse.Cqrs.Commands;

namespace eShop.Basket.Application.Cart.Commands.Delete;

public class AppRemoveBasketCommandHandler(
    ICommandDispatcher commandDispatcher): ICommandHandler<AppRemoveBasketCommand>
{
    public async Task HandleAsync(AppRemoveBasketCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        await commandDispatcher.ExecAsync(new RemoveBasketCommand(command.BuyerId), cancellationToken);
    }
}