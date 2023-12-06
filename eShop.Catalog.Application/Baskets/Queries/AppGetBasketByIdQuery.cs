using Ilse.Cqrs.Queries;

namespace eShop.Catalog.Application.Baskets.Queries;

public record AppGetBasketByIdQuery(string BuyerId): IQuery;