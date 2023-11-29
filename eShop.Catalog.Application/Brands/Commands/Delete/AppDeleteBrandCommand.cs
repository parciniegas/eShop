using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Application.Brands.Commands.Delete;

public record AppDeleteBrandCommand(int Id): ICommand;