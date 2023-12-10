using Ilse.Cqrs.Queries;

namespace eShop.Basket.Domain.Cart.Queries;

// ReSharper disable once ClassNeverInstantiated.Global
public record GetBasketByIdQuery(string Id): IQuery;