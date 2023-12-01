using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.Products.Commands.Update;

// ReSharper disable once ClassNeverInstantiated.Global
public record UpdateProductCommand(string Id, string Name, string Description, int BrandId) : ICommand;