using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.Baskets.Commands.Delete;

// ReSharper disable once ClassNeverInstantiated.Global
public record RemoveBasketCommand(string BuyerId): ICommand;