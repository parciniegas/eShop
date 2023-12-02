using eShop.Catalog.Domain.Products.Commands.Update;
using eShop.Catalog.Domain.Products.Events;
using Ilse.Cqrs.Commands;
using Ilse.Events.Dispatcher;
using Ilse.Events.Queue;
using Microsoft.Extensions.Logging;

namespace eShop.Catalog.Application.Products.Commands.Update;

public class AppProductUpdateCommandHandler(
        ILogger<AppProductUpdateCommand> logger,
        ICommandDispatcher commandDispatcher,
        IEventDispatcher eventDispatcher,
        IEventQueue eventQueue)
    : ICommandHandler<AppProductUpdateCommand>
{
    public async Task HandleAsync(AppProductUpdateCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        await commandDispatcher.ExecAsync(
            new UpdateProductCommand(command.Id, command.Name, command.Description, command.BrandId),
            cancellationToken);
        await HandleEvents(cancellationToken);
    }

    private async Task HandleEvents( 
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling events");
        var productNameChangedEvent = eventQueue.Deque<ProductNameChangedEvent>();
        if (productNameChangedEvent is not null)
            await eventDispatcher.HandleAsync(productNameChangedEvent, cancellationToken);
        var productBrandChangedEvent = eventQueue.Deque<ProductBrandChangedEvent>();
        if (productBrandChangedEvent is not null)
            await eventDispatcher.HandleAsync(productBrandChangedEvent, cancellationToken);
    }
}