using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.Baskets.Commands.Add;

public record RemoveItemFromBasketCommand(string BuyerId, string ProductId, int Quantity): ICommand;