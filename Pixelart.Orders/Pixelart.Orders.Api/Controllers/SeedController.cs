using Microsoft.AspNetCore.Mvc;
using Pixelart.Orders.Infrastructure.Services;

namespace Pixelart.Orders.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeedContoller : ControllerBase
{
    private readonly IDataSeeder _dataSeeder;

    public SeedContoller(IDataSeeder dataSeeder)
    {
        _dataSeeder = dataSeeder;
    }

    [HttpPost("Customers")]
    public async Task SeedCustomersAsync(){
        await _dataSeeder.SeedCustomersAsync();
    }

    [HttpPost("Products")]
    public async Task SeedProductsAsync()
    {
        await _dataSeeder.SeedProductsAsync();
    }
}