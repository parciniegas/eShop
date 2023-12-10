namespace eShop.Basket.API.Endpoints.Delete;

public record RemoveItemFromBasketRequest(string ProductId, int Quantity);