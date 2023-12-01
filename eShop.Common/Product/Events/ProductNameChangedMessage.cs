namespace eShop.Common.Product.Events;

public record ProductNameChangedMessage(string ProductId, int BrandId, string BrandName, Guid CorrelationId) : IMessage;