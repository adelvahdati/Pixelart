using Pixelart.Orders.Core.Entities;
using Pixelart.Orders.Core.Enums;

namespace Pixelart.Orders.Infrastructure.Data;

public class OrderEntity
{
    public Guid Id {get;set;}
    public Guid CustomerId {get;set;}
    public List<OrderItemEntity> Items {get;set;}
    public OrderState Status {get;set;}
    public long TotalPrice {get;set;}

    public virtual CustomerEntity Customer {get;set;}

    public static OrderEntity CreateFrom(Order order)
    {
        throw new NotImplementedException();
    }

    public Order ToOrder(){
        throw new NotImplementedException();
    }    
}