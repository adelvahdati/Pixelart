namespace Pixelart.Orders.Infrastructure.Data;

public class OrderItemEntity
{
    public Guid Id {get;set;}
    public Guid OrderId {get;set;}
    public Guid ProductId {get;set;}
    public long Quantity {get;set;}

    public virtual ProductEntity Product {get;set;}
    public virtual OrderEntity Order {get;set;}
}