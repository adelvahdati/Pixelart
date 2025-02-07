using Microsoft.AspNetCore.Mvc;
using Pixelart.Customers.Core.Commands;
using Pixelart.Customers.Core.Entities;
using Pixelart.Customers.Services.Intefraces;

namespace Pixelaret.Customers.Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    public async Task CreateAsync([FromBody] CreateCustomer command)
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

    [HttpGet("{id}")] // api/customers/8762-77253453-726225
    public async Task<Customer?> GetAsync([FromRoute] Guid id)
    {
        var customer = await _customerService.GetAsync(id);
        return customer;
    }

    [HttpGet]
    public async Task<List<Customer>> ListAsync([FromQuery]int pageIdex,[FromQuery] int pageSize) // api/Customers?pageIndex=1&pageSize=10
    {
        return await _customerService.ListAsync(pageIdex,pageSize);
    }
}