using eShop.Common;
using MassTransit;
using Microsoft.Extensions.Logging;
using IBus = eShop.Catalog.Application.IBus.IBus;

namespace eShop.Catalog.Infrastructure.Bus;

public class Bus(
    ILogger logger,
    IPublishEndpoint publishEndpoint): IBus
{
    public async Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default)
        where TMessage : class, IMessage
    {
        logger.LogInformation("Publishing message {message} with correlationId {message.CorrelationId}",
            typeof(TMessage).Name, message.CorrelationId);
        await publishEndpoint.Publish(message, cancellationToken);
    }
}