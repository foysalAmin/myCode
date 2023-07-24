using ApplicationCore.Common.Shared;
using Domain.OrderAggregate;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Orders.Commands;

public sealed record CreateCommand(
    string Email,
    string PaymentRef,
    string CustomerId,
    string ProductId,
    AddressCommand Address,
    List<ItemCommand> Items) : IRequest<ErrorOr<Order>>;

public sealed record ItemCommand(
    string ProductId,
    string Currency,
    decimal Amount,
    int Qty);
