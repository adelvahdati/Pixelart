
using Pixelart.Orders.Application.Dtos;
using Pixelart.Orders.Application.Intefaces;

namespace Pixelart.Orders.Application.Queries;

public class ListCustomerQuery : IQuery<List<CustomerDto>>
{
    public int PageIndex {get; set;}    
    public int PageSize {get;set;}
}
