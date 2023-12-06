using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.Baskets.Commands.Add;

public class AddItemToBasketCommandHandler(
    IBasketRepository repository): ICommandHandler<AddItemToBasketCommand, Basket>
{
    public async Task<Basket> HandleAsync(AddItemToBasketCommand command, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        var basket = await repository.GetBasketAsync(command.BuyerId, cancellationToken);
        if (basket == null)
        {
            basket = new Basket(command.BuyerId);
            basket.BasketItems.Add(
                new BasketItem(command.ProductId, command.ProductName, command.Quantity, command.UnitPrice));
            await repository.AddBasketAsync(basket, cancellationToken);
            return basket;
        }
                     
        if (basket.BasketItems.Any(x => x.ProductId == command.ProductId))
            basket.BasketItems.First(x => x.ProductId == command.ProductId).Quantity += command.Quantity;
        else
            basket.BasketItems.Add(
                new BasketItem(command.ProductId, command.ProductName, command.Quantity, command.UnitPrice));
        await repository.UpdateBasketAsync(basket, cancellationToken);
        return basket;
    }
}