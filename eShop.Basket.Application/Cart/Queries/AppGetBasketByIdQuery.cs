using Ilse.Cqrs.Queries;

namespace eShop.Basket.Application.Cart.Queries;

public record AppGetBasketByIdQuery(string BuyerId): IQuery;