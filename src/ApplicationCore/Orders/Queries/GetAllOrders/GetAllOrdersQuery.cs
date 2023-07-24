using Domain.OrderAggregate;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Orders.Queries.GetAllOrders;

public sealed record GetAllOrdersQuery() : IRequest<ErrorOr<IEnumerable<Order>>>;
