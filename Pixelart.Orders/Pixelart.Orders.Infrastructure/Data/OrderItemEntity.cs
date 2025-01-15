using Pixelart.Orders.Core.ValueObjects;

namespace Pixelart.Orders.Infrastructure.Data;

public class OrderItemEntity
{
    public Guid Id {get;set;}
    public Guid OrderId {get;set;}
    public Guid ProductId {get;set;}
    public long Quantity {get;set;}

    public virtual ProductEntity Product {get;set;}
    public virtual OrderEntity Order {get;set;}

    public static OrderItemEntity CreateFrom(Guid orderId, OrderItem orderItem){
        var orderItemEntity = new OrderItemEntity();
        orderItemEntity.Id = orderItem.Id;
        orderItemEntity.OrderId = orderId;
        orderItemEntity.ProductId = orderItem.ProductId;
        orderItemEntity.Quantity = orderItem.Quantity.Value;

        return orderItemEntity;

    }
}