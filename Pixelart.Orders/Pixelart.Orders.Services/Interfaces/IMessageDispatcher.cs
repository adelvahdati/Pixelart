using Pixelart.Orders.Core.Interfaces;

namespace Pixelart.Orders.Services.Services;

public interface IMessageDispatcher{

    Task DispatchAsync(IEvent @event);
    Task DispatchAsync(List<IEvent> @events);
}