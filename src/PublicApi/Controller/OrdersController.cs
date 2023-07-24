using ApplicationCore.Orders.Commands;
using ApplicationCore.Orders.Queries.GetAllOrders;
using ApplicationCore.Orders.Queries.GetOrder;
using Contracts.Order;
using Domain.OrderAggregate;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PublicApi.Controller;

[Route("[controller]")]
public class OrdersController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public OrdersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(string id)
    {
        ErrorOr<Order> getResult = await _mediator.Send(new GetOrderQuery(id));

        return getResult.Match(
            result => Ok(_mapper.Map<OrderResponse>(result)),
            errors => Problem(errors));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        ErrorOr<IEnumerable<Order>> getResults = await _mediator.Send(new GetAllOrdersQuery());

        return getResults.Match(
            result => Ok(_mapper.Map<List<OrderResponse>>(result)),
            errors => Problem(errors));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateOrderRequest request)
    {
        var command = _mapper.Map<CreateCommand>(request);

        ErrorOr<Order> createResult = await _mediator.Send(command);

        return createResult.Match(
            result => Ok(_mapper.Map<OrderResponse>(result)),
            errors => Problem(errors));
    }
}
