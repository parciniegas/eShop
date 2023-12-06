namespace eShop.Catalog.API.Endpoints.Baskets.Add;

// ReSharper disable once ClassNeverInstantiated.Global
public record AddItemToBasketRequest(string ProductId, string ProductName, int Quantity, decimal UnitPrice);
