using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.Baskets.Commands.Add;

// ReSharper disable once ClassNeverInstantiated.Global
public record AddItemToBasketCommand(string BuyerId, string ProductId, string ProductName, int Quantity, decimal UnitPrice) : ICommand;