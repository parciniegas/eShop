using Ilse.Cqrs.Commands;

namespace eShop.Basket.Application.Cart.Commands.Delete;

public record AppRemoveBasketCommand(string BuyerId): ICommand;