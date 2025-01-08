using Pixelart.Orders.Core.Interfaces;

namespace Pixelart.Orders.Core.Events;
public class OrderCreated : IEvent
{
    public Guid OrderId {get;set;}
    public Guid CustomerId {get;set;}
}