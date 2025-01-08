using Pixelart.Orders.Core.Entities;
using Pixelart.Orders.Core.ValueObjects;
using Pixelart.Orders.Services.Intefaces;
using Pixelart.Orders.Services.Repositories;
namespace Pixelart.Orders.Services.Services;
public class OrderService : IOrderService
{
    private IOrderRepository _orderRepository;
    private IMessageDispatcher _messageDispatcher;
    private ICustomerService _customerService;
    private IProductService _productService;
    private IMessageBroker _messageBoker;
    public OrderService(IOrderRepository repository, IMessageDispatcher messageDispatcher, ICustomerService customerService, IProductService productService, IMessageBroker messageBoker)
    {
        _orderRepository = repository;
        _messageDispatcher = messageDispatcher;
        _customerService = customerService;
        _productService = productService;
        _messageBoker = messageBoker;
    }

    public async Task CancelOrderAsync(Guid orderId)
    {
        var order = await _orderRepository.GetAsync(orderId);
        if(order == null)
            throw new Exception("Order not found");        
        order.Cancel();        
        await _orderRepository.UpdateAsync(order);
        var events = order.DomainEvents;
        await _messageDispatcher.DispatchAsync(events);
    }


    public async Task CreateOrderAsync(Guid CustomerId, Basket basket)
    {
        var customer = await _customerService.GetCustomerAsync(CustomerId);
        if(customer == null)
            throw new Exception("Customer Not found");
        
        var order = new Order(customer);

        var items = basket.Content;
        foreach(var item in items)
        {
            var productId = item.ProductId;
            var product = await _productService.GetProductAsync(productId);
            if(product == null)
                throw new Exception($"Product with this id not found {productId}");



            var quantity = item.Quantity;
            
            var orderItem = new OrderItem (product.Id,product.Name,product.UnitPrice,Quantity.Create(quantity));

            order.AddOrderItem(orderItem);
        }
        var events = order.DomainEvents;
        order.Clear();      

        await _orderRepository.InsertAsync(order);

        await _messageDispatcher.DispatchAsync(events); 
        await _messageBoker.PublishAsync(events);

        
    }

    public async Task<Order> GetOrderAsync(Guid orderId)
    {
        var order = await _orderRepository.GetAsync(orderId);
        return order;
    }

    public async Task<List<Order>> ListAsync()
    {
        var orders = await _orderRepository.ListAsync();
        return orders;        
    }

    public async Task<List<Order>> ListAsync(Guid CustomerId)
    {
        var orders = await _orderRepository.ListAsync(x=> x.Customer.Id == CustomerId);
        return orders;
    }

    public async Task UpdateOrderAsync(Order order)
    {
        await _orderRepository.UpdateAsync(order);
    }
}