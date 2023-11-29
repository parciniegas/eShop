using eShop.Catalog.Domain.Brands.Commands.Update;
using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Application.Brands.Commands.Update;

public class AppUpdateBrandCommandHandler(
    ICommandDispatcher commandDispatcher): ICommandHandler<AppUpdateBrandCommand>
{
    public async Task HandleAsync(AppUpdateBrandCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var updateBrandCommand = new UpdateBrandCommand(command.Id, command.Name, command.Description);
        await commandDispatcher.ExecAsync(updateBrandCommand, cancellationToken);
    }
}