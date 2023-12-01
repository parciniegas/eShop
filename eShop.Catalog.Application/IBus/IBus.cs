using eShop.Common;

namespace eShop.Catalog.Application.IBus;

public interface IBus
{
    Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default) 
        where TMessage : class, IMessage;
}