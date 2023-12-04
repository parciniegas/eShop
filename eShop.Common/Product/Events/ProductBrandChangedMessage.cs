namespace eShop.Common.Product.Events;

public record ProductBrandChangedMessage(string ProductId, int BrandId, Guid CorrelationId) : IMessage;