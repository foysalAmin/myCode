using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.OrderAggregate;
using Domain.UserAggregate.ValueObjects;

namespace Domain.UserAggregate.Entities;

public sealed class Customer : Entity<CustomerId>
{
    private readonly List<Order?> _orders = new();

    private Customer(
        CustomerId customerId,
        UserId userId,
        Address address) : base(customerId)
    {
        Address = address;
        UserId = userId;
    }

    public UserId UserId { get; private set; }
    public Address Address { get; private set; }

    // Navigation property
    public User User { get; private set; } = null!;
    public IReadOnlyList<Order?> Orders => _orders.AsReadOnly();

    public static Customer Create(
        string phoneNumber,
        string street,
        string city,
        string state,
        string zipCode,
        string country,
        UserId userId)
    {
        return new(
            CustomerId.CreateUnique(),
            userId,
            Address.Create(
                phoneNumber,
                street,
                city,
                state,
                country,
                zipCode));
    }

#pragma warning disable CS8618
    private Customer()
    {
    }
#pragma warning restore CS8618
}
