using eShop.Catalog.Domain.Exceptions;
using Ilse.Cqrs.Commands;
using Ilse.Repository.Contracts;

namespace eShop.Catalog.Domain.Categories.Commands.Add;
public class AddCategoryCommandHandler(
    IRepository repository): ICommandHandler<AddCategoryCommand, AddCategoryCommandResult>
{
    public async Task<AddCategoryCommandResult> 
        HandleAsync(AddCategoryCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var categoryExists = 
            await repository.GetByAsync<Category>(c => c.Name == command.Name, cancellationToken);
        if (categoryExists.Any())
            throw new EntityAlreadyExistsException($"Category with name '{command.Name}' already exists");
        var id = await repository.GetNextSequenceAsync<Category>();
        var category = new Category{Id = id, Name =command.Name, Description = command.Description};
        await repository.AddAsync(category, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return new AddCategoryCommandResult(category.Id); 
    }
}