using ApplicationCore.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Common.ValueObjects;
using Domain.OrderAggregate;
using Domain.OrderAggregate.Eitities;
using Domain.OrderAggregate.ValueObjects;
using Domain.ProductAggregate.ValueObjects;
using Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Orders.Commands;

public sealed class CreateCommandHanfler : IRequestHandler<CreateCommand, ErrorOr<Order>>
{
    private readonly IOrderRepository _orderRepository;

    public CreateCommandHanfler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<ErrorOr<Order>> Handle(CreateCommand command, CancellationToken cancellationToken)
    {
        Order order = Order.Create(
            command.Email,
            command.Address.PhoneNumber,
            command.Address.Street,
            command.Address.City,
            command.Address.State,
            command.Address.ZipCode,
            command.Address.Country,
            command.PaymentRef,
            CustomerId.Create(Guid.Parse(command.CustomerId)));

        foreach (var item in command.Items)
        {
            order.AddItem(
                ProductId.Create(Guid.Parse(item.ProductId)),
                Money.Create(
                    item.Currency,
                    item.Amount),
                item.Qty);
        }

        return await _orderRepository.AddAsync(order) < 1
            ? Errors.Order.InvalidOperation
            : order;
    }
}
