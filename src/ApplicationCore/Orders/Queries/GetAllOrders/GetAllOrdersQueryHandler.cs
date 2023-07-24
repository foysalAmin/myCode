using ApplicationCore.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.OrderAggregate;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Orders.Queries.GetAllOrders;

public sealed class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, ErrorOr<IEnumerable<Order>>>
{
    private readonly IOrderRepository _orderRepository;

    public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<ErrorOr<IEnumerable<Order>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = (List<Order>)await _orderRepository.GetAllOrdersAsync();

        return orders.Count < 1
            ? Errors.Order.NotFound
            : orders;
    }
}
