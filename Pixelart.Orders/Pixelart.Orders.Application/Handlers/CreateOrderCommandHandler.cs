using Pixelart.Orders.Application.Interfaces;
using Pixelart.Orders.Commands;
using Pixelart.Orders.Interfaces;
using Pixelart.Orders.Services.Intefaces;

namespace Pixelart.Orders.Application.Handlers;

public class CreateOrderCommandHandler : ICommandHandler<CreateOrder>
{
    private IOrderService orderService;

    public CreateOrderCommandHandler(IOrderService orderService)
    {
        this.orderService = orderService;
    }

    public async Task HandleAsync(CreateOrder command)
    {
        await orderService.CreateOrderAsync(command.CustomerId,command.Basket);
    }
}