using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Application.Products.Commands.Add;

public record AppAddProductCommand(
    string Id, 
    string Name, 
    string Description, 
    int BrandId, 
    decimal Price,
    int AvailableStock,
    int RestockThreshold,
    List<string> Labels,
    List<CommandTag> Tags,
    List<int> CategoryIds) : ICommand;

public record CommandTag(string Name, string Value);