using eShop.Catalog.Application.Bus;
using eShop.Catalog.Domain.Products.Events;
using eShop.Common.Product.Events;
using Ilse.CorrelationId.Context;
using Ilse.Events.Dispatcher;
using Microsoft.Extensions.Logging;

namespace eShop.Catalog.Application.Products.Events;

public class ProductNameChangedEventHandler(ILogger<ProductNameChangedEventHandler> logger,
        ICorrelationContextAccessor correlationContextAccessor,
        IBus bus) 
    : IEventHandler<ProductNameChangedEvent>
{
    public Task HandleAsync(ProductNameChangedEvent @event, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Product name changed to {name} for product {productId}",
            @event.ProductName, @event.ProductId);
        var context = correlationContextAccessor.CorrelationContext;
        var correlationId = context is null ? new Guid() : new Guid(context.CorrelationId);

        bus.PublishAsync(new ProductNameChangedMessage(@event.ProductId, @event.ProductName,
                     correlationId), cancellationToken);
        return Task.CompletedTask;
    }
}
