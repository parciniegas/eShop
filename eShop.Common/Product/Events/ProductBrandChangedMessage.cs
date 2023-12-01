namespace eShop.Common.Product.Events;

public record ProductBrandChangedMessage(string ProductId, string BrandId, Guid CorrelationId) : IMessage;