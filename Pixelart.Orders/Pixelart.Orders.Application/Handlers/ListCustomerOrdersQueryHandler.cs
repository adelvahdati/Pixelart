using Pixelart.Orders.Application.Dtos;
using Pixelart.Orders.Application.Intefaces;
using Pixelart.Orders.Application.Interfaces;
using Pixelart.Orders.Application.Queries;
using Pixelart.Orders.Services.Repositories;

namespace Pixelart.Orders.Application.Handlers;

public class ListCustomerOrdesQueryHandler : IQueryHandler<ListCustomerOrdesQuery, List<OrderDto>>
{
    // private IOrderRepository orderRepository;

    // public ListCustomerOrdesQueryHandler(IOrderRepository orderRepository)
    // {
    //     this.orderRepository = orderRepository;
    // }

    private IOrderDao orderDao;

    public ListCustomerOrdesQueryHandler(IOrderDao orderDao)
    {
        this.orderDao = orderDao;
    }

    public async Task<List<OrderDto>> HandleAsync(ListCustomerOrdesQuery query)
    {
        var CustomerId = query.CustomerId;
        // var orders = await orderRepository.ListAsync(order => order.Customer.Id == CustomerId);

        // var orderDtos =orders.Select(order=> OrderDto.CreateFrom(order)).ToList();
        var orderDtos = await orderDao.ListCustomerOrdersAsync(CustomerId);

        return orderDtos;

    }
}
