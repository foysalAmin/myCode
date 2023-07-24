using ApplicationCore.Customers.Command;
using ApplicationCore.Customers.Common;
using ApplicationCore.Customers.GetCustomer.Queries;
using ApplicationCore.Customers.Queries.GetAllCustomers;
using Contracts.Customer;
using Domain.UserAggregate.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PublicApi.Controller;

[Route("[controller]")]
public class CustomersController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CustomersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        ErrorOr<IEnumerable<Customer>> getResult = await _mediator.Send(new GetAllCustomersQuery());

        return getResult.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(string id)
    {
        ErrorOr<CustomerResult> getResult = await _mediator.Send(new GetCustomerQuery(id));

        return getResult.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [AllowAnonymous]
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateCustomerRequest request)
    {
        var command = _mapper.Map<CreateCommand>(request);

        ErrorOr<CustomerResult> createResult = await _mediator.Send(command);

        return createResult.Match(
            result => Ok(result),
            errors => Problem(errors));
    }
}
