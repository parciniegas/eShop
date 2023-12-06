using eShop.Common;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace eShop.Catalog.Infrastructure.Bus;

public class Bus(
    ILogger<Bus> logger,
    IPublishEndpoint publishEndpoint): Application.Bus.IBus
{
    public async Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default)
        where TMessage : class, IMessage
    {
        logger.LogTrace("Publishing message {message} with correlationId {message.CorrelationId}",
            typeof(TMessage).Name, message.CorrelationId);
        await publishEndpoint.Publish(message, cancellationToken);
    }
}