using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.CategoriesProducts.Commands.AddCategories;

public record AddCategoriesToProductCommand(string ProductId, List<int> CategoryIds) : ICommand;
