using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Domain.CategoriesProducts.Commands.AddProducts;

public record AddProductsToCategoryCommand(int CategoryId, List<string> ProductIds) : ICommand;
