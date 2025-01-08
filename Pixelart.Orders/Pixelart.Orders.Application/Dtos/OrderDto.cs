using Pixelart.Orders.Core.Entities;

namespace Pixelart.Orders.Application.Dtos;
public class OrderDto
{
    public OrderDto(string customerName, long totalPrice, List<OrderItemDto> orderItems)
    {
        CustomerName = customerName;
        TotalPrice = totalPrice;
        OrderItems = orderItems;
    }

    public string CustomerName {get;set;}
    public long TotalPrice {get;set;}
    public List<OrderItemDto> OrderItems {get;set;}

    public static OrderDto CreateFrom(Order order)
    {
        var items = order.Details.Select(orderItem => OrderItemDto.CretaeFrom(orderItem)).ToList();
        return new OrderDto(order.Customer.Name,order.TotalPrice,items);

    }
}