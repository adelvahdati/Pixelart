using Pixelart.Orders.Interfaces;

namespace Pixelart.Orders.Application.Interfaces;

public interface ICommandHandler<T> where T : ICommand
{
    Task HandleAsync(T command);    
}
