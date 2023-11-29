using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.Brands.Commands.Delete;

public record DeleteBrandByIdCommand(int Id): ICommand;