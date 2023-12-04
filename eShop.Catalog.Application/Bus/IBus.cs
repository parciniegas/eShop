using eShop.Common;

namespace eShop.Catalog.Application.Bus;

public interface IBus
{
    Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default) 
        where TMessage : class, IMessage;
}