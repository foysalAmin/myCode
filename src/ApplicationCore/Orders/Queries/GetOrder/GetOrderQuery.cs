using Domain.OrderAggregate;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Orders.Queries.GetOrder;

public sealed record GetOrderQuery(string Id) : IRequest<ErrorOr<Order>>;
