using Ilse.Events.Queue;

namespace eShop.Catalog.Domain.Products.Events;

public record ProductNameChangedEvent(string ProductId, string ProductName) : IEvent;
