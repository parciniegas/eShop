using Ilse.Cqrs.Commands;

namespace eShop.Basket.Domain.Cart.Commands.Delete;

// ReSharper disable once ClassNeverInstantiated.Global
public record RemoveBasketCommand(string BuyerId): ICommand;