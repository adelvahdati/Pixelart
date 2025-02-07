using Pixelart.Customers.Application.Interfaces;
using Pixelart.Customers.Core.Commands;
using Pixelart.Customers.Services.Intefraces;

namespace Pixelaret.Customers.Applications.Handlers;

public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomer>
{
    private readonly ICustomerService _customerService;

    public CreateCustomerCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task HandleAsync(CreateCustomer command)
    {
        await _customerService.CreateAsync(
            command.Name,
            command.Family,
            command.Address,
            command.ZipCode,
            command.Phone,
            command.BirthDate
        );
    }
}
