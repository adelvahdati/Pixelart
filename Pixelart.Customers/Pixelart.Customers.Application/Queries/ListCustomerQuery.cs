using Pixelaret.Customers.Applications.Dtos;
using Pixelart.Customers.Application.Intefaces;

namespace Pixelaret.Customers.Applications.Queries;
public class ListCustomerQuery : IQuery<List<CustomerDto>>{
    public int PageIndex {get;set;}
    public int PageSize {get;set;}
}