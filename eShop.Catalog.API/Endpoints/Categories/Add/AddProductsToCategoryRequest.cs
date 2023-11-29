namespace eShop.Catalog.API.Endpoints.Categories.Add;

public record AddProductsToCategoryRequest(int CategoryId, List<string> ProductIds);