namespace eShop.Catalog.API.Endpoints.Products.Update;

public record UpdateProductRequest(string Name, string Description, int BrandId);