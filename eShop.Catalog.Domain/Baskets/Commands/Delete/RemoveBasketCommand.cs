using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.Baskets.Commands.Delete;

public record RemoveBasketCommand(string BuyerId): ICommand;