using Pixelart.Orders.Application.Dtos;

namespace Pixelart.Orders.Application.Intefaces;
public interface IOrderDao
{
    Task<List<OrderDto>> ListCustomerOrdersAsync(Guid CustomerId);
}