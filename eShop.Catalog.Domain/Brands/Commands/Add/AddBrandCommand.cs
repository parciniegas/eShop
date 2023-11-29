using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.Brands.Commands.Add;

public record AddBrandCommand(string Name, string? Description) : ICommand;

public record AddBrandCommandResult(int Id);