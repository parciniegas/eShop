using Ilse.Cqrs.Commands;

namespace eShop.Basket.Domain.Cart.Commands.Delete;

// ReSharper disable once ClassNeverInstantiated.Global
public record RemoveItemFromBasketCommand(string BuyerId, string ProductId, int Quantity): ICommand;