using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Application.Categories.Commands;

public record AppAddCategoryCommand(string Name, string? Description): ICommand;
public record AppAddCategoryCommandResult(int Id);