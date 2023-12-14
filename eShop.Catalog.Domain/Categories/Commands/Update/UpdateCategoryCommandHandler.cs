using eShop.Common.Exceptions;
using Ilse.Cqrs.Commands;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Categories.Commands.Update;

public class UpdateCategoryCommandHandler(
    IRepository repository): ICommandHandler<UpdateCategoryCommand>
{
    public async Task HandleAsync(UpdateCategoryCommand command, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        var category = await repository.GetByIdAsync<Category, int>(command.Id, cancellationToken);
        if (category == null)
            throw new EntityNotFoundException($"Category with id '{command.Id}' not found");
        if (command.Name != null && 
            (await repository.GetByAsync<Category>(c => c.Name == command.Name
                                                        && c.Id != command.Id, cancellationToken)).Any())
            throw new EntityAlreadyExistsException($"Category with name '{command.Name}' already exists");
        category.Name = command.Name ?? category.Name;
        category.Description = command.Description;
        await repository.SaveChangesAsync(cancellationToken);
    }
}