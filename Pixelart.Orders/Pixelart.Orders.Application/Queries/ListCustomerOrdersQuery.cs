using Pixelart.Orders.Application.Dtos;
using Pixelart.Orders.Application.Intefaces;

namespace Pixelart.Orders.Application.Queries;

public class ListCustomerOrdesQuery : IQuery<List<OrderDto>>
{
    public Guid CustomerId {get;set;}
}