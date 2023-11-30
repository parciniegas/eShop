using eShop.Catalog.Domain.CategoriesProducts.Commands.AddCategories;
using eShop.Catalog.Domain.Products.Commands.Add;
using Ilse.Cqrs.Commands;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Application.Products.Commands.Add;

public class AppAddProductCommandHandler(
    ICommandDispatcher commandDispatcher, 
    IRepository repository): ICommandHandler<AppAddProductCommand>
{
    public async Task HandleAsync(AppAddProductCommand command, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        var addCategoriesToProductCommand = new AddCategoriesToProductCommand(command.Id, command.CategoryIds);
        var addProductCommand = new AddProductCommand(command.Id, command.Name, command.Description,
            command.BrandId,
            command.Price, command.AvailableStock, command.RestockThreshold, command.Labels,
            command.Tags.Select(t => new Domain.Products.Commands.Add.CommandTag(t.Name, t.Value)).ToList());

        using var transaction = await repository.BeginTransactionAsync(cancellationToken);
        await commandDispatcher.ExecAsync(addProductCommand, cancellationToken);
        await commandDispatcher.ExecAsync(addCategoriesToProductCommand, cancellationToken);
        transaction.Commit();
    }
}