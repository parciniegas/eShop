using eShop.Catalog.Domain.Products.Events;
using Ilse.Events.Dispatcher;
using Microsoft.Extensions.Logging;

namespace eShop.Catalog.Application.Products.Events;

public class ProductNameChangedEventHandler(ILogger<ProductNameChangedEventHandler> logger) 
    : IEventHandler<ProductNameChangedEvent>
{
    public Task HandleAsync(ProductNameChangedEvent @event, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Product name changed to {name} for product {productId}",
            @event.ProductName, @event.ProductId);
        return Task.CompletedTask;
    }
}
