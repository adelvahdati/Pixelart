using Pixelaret.Customers.Applications.Dtos;
using Pixelart.Customers.Application.Intefaces;

namespace Pixelaret.Customers.Applications.Queries;
public class GetCustomerQuery : IQuery<CustomerDto?>{
    public Guid CustomerId {get;set;}
}