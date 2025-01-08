using Microsoft.AspNetCore.Mvc;

namespace Pixelart.Orders.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{

    [HttpGet("Find/{id}")]
    public string GetOrderAsyn( Guid orderId){
        throw new NotImplementedException();
    }
}