using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Application.Brands.Commands.Add;

// ReSharper disable once ClassNeverInstantiated.Global
public record AppAddBrandCommand(string Name, string? Description): ICommand;

public record AppAddBrandCommandResult(int Id); 