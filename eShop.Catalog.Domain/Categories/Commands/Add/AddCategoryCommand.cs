using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.Categories.Commands.Add;

public record AddCategoryCommand(string Name, string? Description) : ICommand;
public record AddCategoryCommandResult(int Id);