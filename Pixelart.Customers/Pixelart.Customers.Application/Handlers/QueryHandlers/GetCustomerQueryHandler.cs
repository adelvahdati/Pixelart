using Pixelaret.Customers.Applications.Dtos;
using Pixelaret.Customers.Applications.Queries;
using Pixelart.Customers.Application.Intefaces;
using Pixelart.Customers.Services.Repository;

namespace Pixelaret.Customers.Applications.Handlers;

public class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, CustomerDto?>
{
    private readonly ICustomerRepository customerRepository;

    public GetCustomerQueryHandler(ICustomerRepository customerRepository)
    {
        this.customerRepository = customerRepository;
    }

    public async Task<CustomerDto?> HandleAsync(GetCustomerQuery query)
    {
        var customer = await customerRepository.GetAsync(query.CustomerId);
        if(customer == null)
            return null;
        
        return CustomerDto.CreateFrom(customer);
    }
}
