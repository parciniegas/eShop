using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Application.Baskets.Commands.Delete;

public record AppRemoveItemFromBasketCommand(string BuyerId, string ProductId, int Quantity): ICommand;