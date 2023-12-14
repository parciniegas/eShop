using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.Categories.Commands.Update;

public record UpdateCategoryCommand(int Id, string? Name, string? Description) : ICommand;