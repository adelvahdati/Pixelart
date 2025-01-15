using Pixelart.Orders.Core.Entities;
using Pixelart.Orders.Core.Enums;
using Pixelart.Orders.Core.ValueObjects;

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
        var orderEntity = new OrderEntity();
        orderEntity.Id = order.Id;
        orderEntity.CustomerId = order.Customer.Id;
        orderEntity.Status = order.State;
        orderEntity.TotalPrice = order.TotalPrice;
        orderEntity.Items = order.Details.Select(orderItem=> OrderItemEntity.CreateFrom(order.Id,orderItem)).ToList();

        return orderEntity;
    }

    public Order ToOrder(){
        var orderItems = Items.Select(orderItemEntity=> 
                                        new OrderItem(
                                            orderItemEntity.ProductId,
                                            orderItemEntity.Product.Name,
                                            Price.Create(orderItemEntity.Product.Price),
                                            Quantity.Create(orderItemEntity.Quantity))).ToList();
        var customer = new Customer(Customer.Id,Customer.Name,Customer.Family);

        var order = new Order(Id,orderItems,customer,Status,TotalPrice);

        return order;
    }    
}