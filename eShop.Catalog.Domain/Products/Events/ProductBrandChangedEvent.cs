using Ilse.Events.Queue;

namespace eShop.Catalog.Domain.Products.Events;

public record ProductBrandChangedEvent(string ProductId, int ProductBrandId) : IEvent;