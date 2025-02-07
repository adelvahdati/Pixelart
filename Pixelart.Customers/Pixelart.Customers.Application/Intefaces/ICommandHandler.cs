using Pixelaret.Customers.Core.Interfaces;



namespace Pixelart.Customers.Application.Interfaces;

public interface ICommandHandler<T> where T : ICommand
{
    Task HandleAsync(T command);    
}
