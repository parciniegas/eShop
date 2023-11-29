using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.Brands.Commands.Update;

public record UpdateBrandCommand(int Id, string Name, string? Description) : ICommand;
