using Pixelart.Orders.Core.Interfaces;

namespace Pixelart.Orders.Services.Intefaces;
public interface IMessageBroker{

    Task PublishAsync(IEvent @event);
    Task PublishAsync(List<IEvent> @events);
}