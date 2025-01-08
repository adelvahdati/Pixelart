using Pixelart.Orders.Core.Entities;
using Pixelart.Orders.Core.ValueObjects;
using Pixelart.Orders.Services.DTOS;
namespace Pixelart.Orders.Services.Intefaces;

public interface IOrderService
{
    Task CreateOrderAsync(Guid CustomerId, Basket basket);    
    Task CancelOrderAsync(Guid orderId);
    Task UpdateOrderAsync(Order order);
    Task<List<Order>> ListAsync();
    Task<List<Order>> ListAsync(Guid CustomerId);
    Task<Order> GetOrderAsync(Guid orderId);   
}