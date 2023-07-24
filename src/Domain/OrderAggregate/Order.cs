using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.OrderAggregate.Eitities;
using Domain.OrderAggregate.ValueObjects;
using Domain.ProductAggregate;
using Domain.ProductAggregate.ValueObjects;
using Domain.UserAggregate.Entities;
using Domain.UserAggregate.ValueObjects;

namespace Domain.OrderAggregate;

public sealed class Order : AggregateRoot<OrderId>
{
    private readonly List<Item> _items = new();

    public Order(
        OrderId orderId,
        string email,
        PaymentRef paymentRef,
        Address shipToAddress,
        CustomerId customerId) : base(orderId)
    {
        Email = email;
        PaymentRef = paymentRef;
        ShipToAddress = shipToAddress;
        CustomerId = customerId;
    }

    public string Email { get; private set; }
    public PaymentRef PaymentRef { get; private set; }
    public Address ShipToAddress { get; private set; }
    public CustomerId CustomerId { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    // Navigation property
    public Customer Customer { get; private set; } = null!;
    public IReadOnlyList<Item> Items => _items.AsReadOnly();

    public static Order Create(
        string email,
        string phoneNumber,
        string street,
        string city,
        string state,
        string zipCode,
        string country,
        string paymentRef,
        CustomerId customerId)
    {
        return new(
            OrderId.CreateUnique(),
            email,
            PaymentRef.Create(paymentRef),
            Address.Create(
                phoneNumber,
                street,
                city,
                state,
                zipCode,
                country),
            customerId);
    }

    public void AddItem(
        ProductId productId,
        Money price,
        int qty)
    {
        var item = Item.Create(
            Id,
            productId,
            price,
            qty);

        _items.Add(item);
    }

    public void RemoveItem(Product product)
    {
        // TODO: remove the item from list.
    }

    public string Total()
    {
        var total = 0m;
        foreach (var item in _items)
        {
            total += item.Total;
        }

        return $"${total:N2}";
    }

    public decimal TotalAmount()
    {
        var total = 0m;
        foreach (var item in _items)
        {
            total += item.Total;
        }

        return total;
    }

#pragma warning disable CS8618
    private Order()
    {
    }
#pragma warning restore CS8618
}
