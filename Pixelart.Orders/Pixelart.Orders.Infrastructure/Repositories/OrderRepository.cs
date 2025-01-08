using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Pixelart.Orders.Core.Entities;
using Pixelart.Orders.Core.ValueObjects;
using Pixelart.Orders.Infrastructure.Data;
using Pixelart.Orders.Services.Repositories;

namespace Pixelart.Orders.Infrastructure.Repositories;
public class OrderRepository : IOrderRepository
{
    private ApplicationDbContext _dbContext;

    public OrderRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task DeleteAsycn(Guid id)
    {
        var orderEntity = _dbContext.Orders.Find(id);
        if(orderEntity == null)
            return;

        _dbContext.Remove(orderEntity);
        await _dbContext.SaveChangesAsync();

    }

    public async Task<Order> GetAsync(Guid id)
    {
        var orderEntity = await _dbContext.Orders.FindAsync(id);
        if(orderEntity == null)
            return null;            
        
        return orderEntity.ToOrder();
    }

    public async Task InsertAsync(Order order)
    {
        await _dbContext.Orders.AddAsync(OrderEntity.CreateFrom(order));
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Order>> ListAsync()
    {
        
        var orders =await _dbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                    .Select(orderEntity => new Order(
                        orderEntity.Id,
                        orderEntity.Items.Select(item=> 
                                            new OrderItem(
                                                item.Id,
                                                item.Product.Name,
                                                Price.Create(item.Product.Price),
                                                Quantity.Create(item.Quantity)
                                            )).ToList(),
                        new Customer(orderEntity.Customer.Id,orderEntity.Customer.Name,orderEntity.Customer.Family),
                        orderEntity.Status,
                        orderEntity.TotalPrice
                    )).ToListAsync();

                
        return orders;
    }

    public async Task<List<Order>> ListAsync(Func<Order, bool> condition)
    {
        Expression<Func<OrderEntity,bool>> expression = 
                    orderEntity => condition(orderEntity.ToOrder());

        var orderEntities = await _dbContext.Orders.Where(expression).ToListAsync();

        return orderEntities.Select(orderEntity=>orderEntity.ToOrder())
                            .ToList();

    }

    public async Task UpdateAsync(Order order)
    {
        _dbContext.Entry(order).State = EntityState.Modified;
        //_dbContext.Update(OrderEntity.CreateFrom(order));
         await _dbContext.SaveChangesAsync();
    }
}
