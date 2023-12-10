namespace eShop.Basket.API.Endpoints.Add;

public record AddItemToBasketRequest(string ProductId, string ProductName, int Quantity, decimal UnitPrice);