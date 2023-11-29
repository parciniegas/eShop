using eShop.Catalog.Domain.Brands.Commands.Add;
using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Application.Brands.Commands.Add;

public class AppAddBrandCommandHandler(
    ICommandDispatcher commandDispatcher) : ICommandHandler<AppAddBrandCommand, AppAddBrandCommandResult>
{
    public async Task<AppAddBrandCommandResult> HandleAsync(AppAddBrandCommand command, 
        CancellationToken cancellationToken = default)
    {
        AddBrandCommand addBrandCommand = new(command.Name, command.Description);
        var commandResult =
            await commandDispatcher.ExecAsync<AddBrandCommand, AddBrandCommandResult>(addBrandCommand, cancellationToken);

        var result = new AppAddBrandCommandResult(commandResult.Id);
        return result;
    }
}
