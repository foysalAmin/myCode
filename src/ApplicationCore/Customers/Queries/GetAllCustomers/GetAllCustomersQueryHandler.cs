using ApplicationCore.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.UserAggregate.Entities;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Customers.Queries.GetAllCustomers;

public sealed class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, ErrorOr<IEnumerable<Customer>>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<IEnumerable<Customer>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = (List<Customer>)await _customerRepository.GetAllCustomersAsync();

        return customers.Count < 1
            ? Errors.Customer.NotFound
            : customers;
    }
}
