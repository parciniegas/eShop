namespace eShop.Catalog.API.Endpoints.Products.Add;

// ReSharper disable once ClassNeverInstantiated.Global
public record AddProductRequest(
    string Id, 
    string Name, 
    string Description, 
    int BrandId, 
    decimal Price,
    int AvailableStock,
    int RestockThreshold,
    List<string> Labels,
    List<CommandTag> Tags,
    List<int> CategoryIds);

public record CommandTag(string Name, string Value);

// ReSharper disable once NotAccessedPositionalProperty.Global
public record AddProductRequestResult(string Id);