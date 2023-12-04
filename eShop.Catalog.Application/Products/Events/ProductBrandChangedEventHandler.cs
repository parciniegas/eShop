using eShop.Catalog.Application.Bus;
using eShop.Catalog.Domain.Products.Events;
using eShop.Common.Product.Events;
using Ilse.CorrelationId.Context;
using Ilse.Events.Dispatcher;
using Microsoft.Extensions.Logging;

namespace eShop.Catalog.Application.Products.Events;

public class ProductBrandChangedEventHandler(
    ILogger<ProductBrandChangedEventHandler> logger,
    ICorrelationContextAccessor contextAccessor,
    IBus bus): IEventHandler<ProductBrandChangedEvent>
{
    public Task HandleAsync(ProductBrandChangedEvent @event, 
        CancellationToken cancellationToken = new CancellationToken())
    {
        logger.LogInformation("Product brand changed to {brand} for product {productId}",
            @event.ProductBrandId, @event.ProductId);
        var context = contextAccessor.CorrelationContext;
        var correlationId = context is null ? new Guid() : new Guid(context.CorrelationId);

        bus.PublishAsync(new ProductBrandChangedMessage(@event.ProductId, @event.ProductBrandId,
            correlationId), cancellationToken);
        return Task.CompletedTask;
    }
}