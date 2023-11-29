using eShop.Catalog.Domain.Categories.Commands.Add;
using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Application.Categories.Commands;

public class AppAddCategoryCommandHandler(
    ICommandDispatcher commandDispatcher): ICommandHandler<AppAddCategoryCommand, AppAddCategoryCommandResult>
{
    public async Task<AppAddCategoryCommandResult> 
        HandleAsync(AppAddCategoryCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        AddCategoryCommand addCategoryCommand = new(command.Name, command.Description);
        var result = await commandDispatcher.ExecAsync<AddCategoryCommand, AddCategoryCommandResult>
                (addCategoryCommand, cancellationToken);
        return new AppAddCategoryCommandResult(result.Id);
    }
}