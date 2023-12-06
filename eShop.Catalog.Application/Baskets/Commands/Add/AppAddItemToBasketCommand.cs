using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Application.Baskets.Commands.Add;

// ReSharper disable once ClassNeverInstantiated.Global
public record AppAddItemToBasketCommand(string BuyerId, string ProductId, string ProductName, int Quantity, decimal UnitPrice) : ICommand;