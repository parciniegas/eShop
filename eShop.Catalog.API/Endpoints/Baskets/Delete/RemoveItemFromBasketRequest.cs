namespace eShop.Catalog.API.Endpoints.Baskets.Delete;

public record RemoveItemFromBasketRequest(string ProductId, int Quantity);