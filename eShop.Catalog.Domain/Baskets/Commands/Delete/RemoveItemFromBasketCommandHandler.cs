using eShop.Catalog.Domain.Exceptions;
using Ilse.Cqrs.Commands;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Baskets.Commands.Delete;

public class RemoveItemFromBasketCommandHandler(
    IRepository repository): 
    ICommandHandler<RemoveItemFromBasketCommand, Basket>
{
    public async Task<Basket> HandleAsync(RemoveItemFromBasketCommand command, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        var basket = await repository.GetByIdAsync<Basket, string>(command.BuyerId, cancellationToken);
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
            await repository.DeleteAsync(basket, cancellationToken);
        else
            await repository.UpdateAsync(basket, cancellationToken);
        
        await repository.SaveChangesAsync(cancellationToken);
        return basket;
    }
}