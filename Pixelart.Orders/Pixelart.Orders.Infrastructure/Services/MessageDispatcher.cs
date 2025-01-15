using Pixelart.Orders.Core.Interfaces;
using Pixelart.Orders.Services.Services;

namespace Pixelart.Orders.Infrastructure.Services;

public class MessageDispahcer : IMessageDispatcher
{    
    public Task DispatchAsync(IEvent @event)
    {
        return Task.CompletedTask;
    }

    public Task DispatchAsync(List<IEvent> events)
    {
        return Task.CompletedTask;
    }
}
