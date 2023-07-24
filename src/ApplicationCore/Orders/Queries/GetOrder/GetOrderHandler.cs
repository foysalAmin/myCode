using ApplicationCore.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.OrderAggregate;
using Domain.OrderAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Orders.Queries.GetOrder;

public sealed class GetOrderHandler : IRequestHandler<GetOrderQuery, ErrorOr<Order>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<ErrorOr<Order>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetOrderByIdAsync(OrderId.Create(Guid.Parse(request.Id)));

        return order is null
            ? Errors.Order.NotFound
            : order;
    }
}
