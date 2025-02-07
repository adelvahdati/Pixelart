using Pixelart.Customers.Application.Interfaces;
using Pixelart.Customers.Core.Commands;
using Pixelart.Customers.Services.Intefraces;

namespace Pixelaret.Customers.Applications.Handlers;

public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomer>
{
    private readonly ICustomerService _customerService;

    public DeleteCustomerCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task HandleAsync(DeleteCustomer command)
    {
        await _customerService.DeleteAsync(command.CustomerId);
    }
}
