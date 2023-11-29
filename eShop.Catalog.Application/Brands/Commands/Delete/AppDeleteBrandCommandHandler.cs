using eShop.Catalog.Domain.Brands.Commands.Delete;
using Ilse.Cqrs.Commands;

namespace eShop.Catalog.Application.Brands.Commands.Delete;

public class AppDeleteBrandCommandHandler(
    ICommandDispatcher commandDispatcher): ICommandHandler<AppDeleteBrandCommand>
{
    public async Task HandleAsync(AppDeleteBrandCommand command, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        await commandDispatcher.ExecAsync(new DeleteBrandByIdCommand(command.Id), cancellationToken);
    }
}