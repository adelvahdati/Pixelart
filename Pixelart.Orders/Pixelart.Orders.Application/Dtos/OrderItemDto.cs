using Pixelart.Orders.Core.ValueObjects;

namespace Pixelart.Orders.Application.Dtos;
public class OrderItemDto
{
    public OrderItemDto(string name, long unitPrice, long quantity)
    {
        Name = name;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public string Name { get; set;}
    public long UnitPrice { get; set;}
    public long Quantity { get; set;}

    public static OrderItemDto CretaeFrom(OrderItem orderItem)
    {
        return new OrderItemDto(orderItem.Name,orderItem.UnitPrice.Value, orderItem.Quantity.Value);
    }
}