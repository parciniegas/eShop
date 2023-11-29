using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Application.Brands.Commands.Update;

public record AppUpdateBrandCommand(int Id, string Name, string? Description): ICommand;
