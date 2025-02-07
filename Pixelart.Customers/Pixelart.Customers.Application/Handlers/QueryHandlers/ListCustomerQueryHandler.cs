using Pixelaret.Customers.Applications.Dtos;
using Pixelaret.Customers.Applications.Queries;
using Pixelart.Customers.Application.Intefaces;
using Pixelart.Customers.Services.Repository;

namespace Pixelaret.Customers.Applications.Handlers;

public class ListCustomerQueryHandler : IQueryHandler<ListCustomerQuery, List<CustomerDto>>
{
    private readonly ICustomerRepository customerRepository;

    public ListCustomerQueryHandler(ICustomerRepository customerRepository)
    {
        this.customerRepository = customerRepository;
    }

    public async Task<List<CustomerDto>> HandleAsync(ListCustomerQuery query)
    {
        var customers = await customerRepository.ListAsync(query.PageIndex,query.PageSize);

        if(customers == null)
            return new();
        
        return customers.Select(item=> CustomerDto.CreateFrom(item)).ToList();
    }
}
