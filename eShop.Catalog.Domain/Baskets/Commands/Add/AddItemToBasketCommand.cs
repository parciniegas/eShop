using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.Baskets.Commands.Add;

public record AddItemToBasketCommand(string BuyerId, string ProductId, string ProductName, int Quantity, decimal UnitPrice) : ICommand;