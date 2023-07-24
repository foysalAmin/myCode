using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.OrderAggregate.ValueObjects;
using Domain.ProductAggregate;
using Domain.ProductAggregate.ValueObjects;

namespace Domain.OrderAggregate.Eitities;

public sealed class Item : Entity<ItemId>
{
    private Item(
        ItemId id,
        OrderId orderId,
        ProductId productId,
        Money price,
        int qty) : base(id)
    {
        OrderId = orderId;
        ProductId = productId;
        Price = price;
        Qty = qty;
    }

    public OrderId OrderId { get; private set; }
    public ProductId ProductId { get; private set; }
    public Money Price { get; private set; }
    public int Qty { get; private set; }

    // Navigation property
    public Order Order { get; private set; } = null!;
    public Product Product { get; private set; } = null!;

    public decimal Total => Price.Amount * Qty;

    public static Item Create(
        OrderId orderId,
        ProductId productId,
        Money price,
        int qty)
    {
        return new(
            ItemId.CreateUnique(),
            orderId,
            productId,
            price,
            qty);
    }

#pragma warning disable CS8618
    private Item()
    {
    }
#pragma warning restore CS8618
}
