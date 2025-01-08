using Pixelart.Orders.Application.Dtos;
using Pixelart.Orders.Application.Interfaces;
using Pixelart.Orders.Application.Queries;

namespace Pixelart.Orders.Application.Handlers;

public class ListCustomerHandler : IQueryHandler<ListCustomerQuery, List<CustomerDto>>
{
    public Task<List<CustomerDto>> HandleAsync(ListCustomerQuery query)
    {
        throw new NotImplementedException();
    }
}
