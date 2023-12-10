using Ilse.Cqrs.Commands;

namespace eShop.Basket.Application.Cart.Commands.Delete;

public record AppRemoveItemFromBasketCommand(string BuyerId, string ProductId, int Quantity): ICommand;