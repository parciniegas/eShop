using Ilse.Cqrs.Commands;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Baskets.Commands.Add;

public class AddItemToBasketCommandHandler(
    IRepository repository): ICommandHandler<AddItemToBasketCommand, Basket>
{
    public async Task<Basket> HandleAsync(AddItemToBasketCommand command, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        var basket = await repository.GetByIdAsync<Basket, string>(command.BuyerId, cancellationToken) 
                     ?? new Basket(command.BuyerId);
        if (basket.BasketItems.Any(x => x.ProductId == command.ProductId))
            basket.BasketItems.First(x => x.ProductId == command.ProductId).Quantity += command.Quantity;
        else
            basket.BasketItems.Add(
                new BasketItem(command.ProductId, command.ProductName, command.Quantity, command.UnitPrice));
        await repository.SaveChangesAsync(cancellationToken);
        return basket;
    }
}