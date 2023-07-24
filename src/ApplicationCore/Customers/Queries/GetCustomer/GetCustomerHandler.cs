using ApplicationCore.Common.Interfaces.Persistence;
using ApplicationCore.Common.Shared;
using ApplicationCore.Customers.Common;
using Domain.Common.Errors;
using Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Customers.GetCustomer.Queries;

public sealed class GetCustomerHandler : IRequestHandler<GetCustomerQuery, ErrorOr<CustomerResult>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<CustomerResult>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(CustomerId.Create(Guid.Parse(request.Id)));

        return customer is null
            ? Errors.Customer.NotFound
            : new CustomerResult(
                customer.Id.Value.ToString(),
                customer.UserId.Value.ToString(),
                new AddressCommand(
                    customer.Address.PhoneNumber,
                    customer.Address.Street,
                    customer.Address.City,
                    customer.Address.State,
                    customer.Address.ZipCode,
                    customer.Address.Country),
                customer.Orders.Count,
                null,
                null);
    }
}
