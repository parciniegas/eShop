namespace eShop.Common;

public interface IMessage
{
    public Guid CorrelationId { get; init; }
}