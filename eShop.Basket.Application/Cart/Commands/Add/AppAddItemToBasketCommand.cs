using Ilse.Cqrs.Commands;

namespace eShop.Basket.Application.Cart.Commands.Add;

// ReSharper disable once ClassNeverInstantiated.Global
public record AppAddItemToBasketCommand(string BuyerId, string ProductId, string ProductName, int Quantity, decimal UnitPrice) : ICommand;