using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Application.Baskets.Commands.Delete;

public record AppRemoveBasketCommand(string BuyerId): ICommand;