using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.Products.Commands.Update;

public record UpdateProductCommand(string Id, string Name, string Description, int BrandId) : ICommand;