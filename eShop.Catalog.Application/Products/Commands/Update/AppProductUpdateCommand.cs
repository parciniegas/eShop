using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Application.Products.Commands.Update;

// ReSharper disable once ClassNeverInstantiated.Global
public record AppProductUpdateCommand(string Id, string Name, string Description, int BrandId) : ICommand;
