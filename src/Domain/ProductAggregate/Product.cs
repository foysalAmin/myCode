using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.ProductAggregate.ValueObjects;

namespace Domain.ProductAggregate;

public sealed class Product : AggregateRoot<ProductId>
{
    private Product(
        ProductId productId,
        string name,
        string description,
        Money price) : base(productId)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public Money Price { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public static Product Create(
        string name,
        string description,
        string currency,
        decimal price)
    {
        return new(
            ProductId.CreateUnique(),
            name,
            description,
            Money.Create(currency, price));
    }

#pragma warning disable CS8618
    private Product()
    {
    }
#pragma warning restore CS8618
}
