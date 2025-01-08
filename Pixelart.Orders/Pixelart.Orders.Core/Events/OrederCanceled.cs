using Pixelart.Orders.Core.Interfaces;

namespace Pixelart.Orders.Core.Events;

public class OrderCanceled : IEvent{
    public OrderCanceled(Guid orderId, Guid customerId)
    {
        OrderId = orderId;
        CustomerId = customerId;
    }

    public Guid OrderId {get;set;}
    public Guid CustomerId {get;set;}
}