using Pixelart.Customers.Application.Interfaces;
using Pixelart.Customers.Core.Commands;
using Pixelart.Customers.Services.Intefraces;

namespace Pixelaret.Customers.Applications.Handlers;

public class UpdateCsutomerCommandHandler : ICommandHandler<UpdateCustomer>
{
    private readonly ICustomerService _customerService;

    public UpdateCsutomerCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task HandleAsync(UpdateCustomer command)
    {
        var customer = await _customerService.GetAsync(command.Id);
        if(customer == null)
            throw new Exception("Customer Not Found");
                
        customer.Update(command.Name,command.Family,command.Address,command.ZipCode,command.Phone,command.BirthDate);                    
        await _customerService.UpdateAsync(customer);        
    }
}
