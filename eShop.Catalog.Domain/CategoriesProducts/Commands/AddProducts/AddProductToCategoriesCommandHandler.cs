using Ilse.Cqrs.Commands;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.CategoriesProducts.Commands.AddProducts;
public class AddProductToCategoriesCommandHandler(
    IRepository repository) : ICommandHandler<AddProductsToCategoryCommand>
{
    public async Task HandleAsync(AddProductsToCategoryCommand command, CancellationToken cancellationToken = default)
    {  
        var categoryProductsList = 
            command.ProductIds.Select(id => new CategoryProduct { ProductId = id, CategoryId = command.CategoryId });
        await repository.AddRangeAsync(categoryProductsList, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }
}
