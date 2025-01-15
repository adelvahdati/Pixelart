using Pixelart.Orders.Core.Interfaces;
using Pixelart.Orders.Services.Intefaces;

namespace Pixelart.Orders.Infrastructure.Services;
public class MessageBroker : IMessageBroker
{
    public Task PublishAsync(IEvent @event)
    {
        return Task.CompletedTask;
    }

    public Task PublishAsync(List<IEvent> events)
    {
        return Task.CompletedTask;
    }
}
