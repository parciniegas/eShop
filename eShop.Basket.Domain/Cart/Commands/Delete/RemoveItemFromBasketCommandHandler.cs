using eShop.Common.Exceptions;
using Ilse.Cqrs.Commands;

namespace eShop.Basket.Domain.Cart.Commands.Delete;

public class RemoveItemFromBasketCommandHandler(
    IBasketRepository repository): 
    ICommandHandler<RemoveItemFromBasketCommand, Basket>
{
    public async Task<Basket> HandleAsync(RemoveItemFromBasketCommand command, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        var basket = await repository.GetBasketAsync(command.BuyerId, cancellationToken);
        if (basket == null)
            throw new EntityNotFoundException($"Basket with id '{command.BuyerId}' not found!");
        var basketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == command.ProductId);
        
        if (basketItem == null)
            throw new EntityNotFoundException($"BasketItem with id '{command.ProductId}' not found!");
        
        if (basketItem.Quantity > command.Quantity)
            basketItem.Quantity -= command.Quantity;
        else
            basket.BasketItems.Remove(basketItem);
        
        if (basket.BasketItems.Count == 0)
            await repository.DeleteBasketAsync(basket.BuyerId, cancellationToken);
        else
            await repository.UpdateBasketAsync(basket, cancellationToken);
        
        return basket;
    }
}