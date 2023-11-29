using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.Products.Commands.Add;

public record AddProductCommand(
    string Id, 
    string Name, 
    string Description, 
    int BrandId, 
    decimal Price,
    int AvailableStock,
    int RestockThreshold,
    List<string> Labels,
    List<CommandTag> Tags): ICommand;

public record CommandTag(string Name, string Value);
