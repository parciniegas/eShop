using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.Baskets.Commands.Add;

public class RemoveItemFromBasketCommandHandler: 
    ICommandHandler<RemoveItemFromBasketCommand, Basket>
{
    public async Task<Basket> HandleAsync(RemoveItemFromBasketCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }
}