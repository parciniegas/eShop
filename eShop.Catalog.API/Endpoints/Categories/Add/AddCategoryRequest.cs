namespace eShop.Catalog.API.Endpoints.Categories.Add;

public record AddCategoryRequest(string Name, string? Description);
public record AddCategoryRequestResult(int Id);