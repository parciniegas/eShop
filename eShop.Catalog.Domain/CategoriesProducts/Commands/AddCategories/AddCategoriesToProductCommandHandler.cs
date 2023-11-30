using Ilse.Cqrs.Commands;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.CategoriesProducts.Commands.AddCategories;
public class AddCategoriesToProductCommandHandler(
    IRepository repository) : ICommandHandler<AddCategoriesToProductCommand>
{
    public async Task HandleAsync(AddCategoriesToProductCommand command, CancellationToken cancellationToken = default)
    {
        var categoryProductList = 
            command.CategoryIds.Select(id => new CategoryProduct { CategoryId = id, ProductId = command.ProductId }).ToList();
        await repository.AddRangeAsync(categoryProductList, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }
}
