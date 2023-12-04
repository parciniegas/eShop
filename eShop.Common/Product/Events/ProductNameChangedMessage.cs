namespace eShop.Common.Product.Events;

public record ProductNameChangedMessage(string ProductId, string BrandName, Guid CorrelationId) : IMessage;