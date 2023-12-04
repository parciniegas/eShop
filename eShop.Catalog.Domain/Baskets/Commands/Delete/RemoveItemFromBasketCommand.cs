using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.Baskets.Commands.Delete;

// ReSharper disable once ClassNeverInstantiated.Global
public record RemoveItemFromBasketCommand(string BuyerId, string ProductId, int Quantity): ICommand;