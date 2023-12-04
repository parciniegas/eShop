using Ilse.Cqrs.Queries;

namespace eShop.Catalog.Domain.Baskets.Commands.Queries;

// ReSharper disable once ClassNeverInstantiated.Global
public record GetBasketByIdQuery(string Id): IQuery;