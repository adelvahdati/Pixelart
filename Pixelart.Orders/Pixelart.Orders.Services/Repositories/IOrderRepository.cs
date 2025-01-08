using Pixelart.Orders.Core.Entities;

namespace Pixelart.Orders.Services.Repositories;
public interface IOrderRepository
{
    Task InsertAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsycn(Guid id);
    Task<Order> GetAsync(Guid id);
    Task<List<Order>> ListAsync();
    Task<List<Order>> ListAsync(Func<Order,bool> condition);
}