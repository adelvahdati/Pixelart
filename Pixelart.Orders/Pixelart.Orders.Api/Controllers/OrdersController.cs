using Microsoft.AspNetCore.Mvc;
using Pixelart.Orders.Commands;
using Pixelart.Orders.Core.Entities;
using Pixelart.Orders.Services.Intefaces;

namespace Pixelart.Orders.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task CreateOrder([FromBody] CreateOrder request)
    {
        await _orderService.CreateOrderAsync(request.CustomerId,request.Basket);
    } 


    [HttpGet("Find/{orderId}")]
    public async Task<Order> GetOrderAsyn(Guid orderId){
        return   await _orderService.GetOrderAsync(orderId);        
    }
}