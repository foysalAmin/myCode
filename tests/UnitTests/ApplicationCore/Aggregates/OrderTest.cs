using Domain.OrderAggregate.Eitities;
using Domain.OrderAggregate.ValueObjects;
using UnitTests.Builders;

namespace UnitTests.ApplicationCore.Aggregates;

public class OrderTest
{
    [Fact]
    public void IsZeroForNewOrder()
    {
        var order = new OrderBuilder().WithNoItems();

        Assert.Equal(0, order.TotalAmount());
    }

    [Fact]
    public void IsCorrectGiven1Item()
    {
        var builder = new OrderBuilder();
        var items = new List<Item>
        {
            Item.Create(
                builder.TestOrderId,
                builder.TestProductId,
                builder.TestPrice,
                1),
        };

        var order = new OrderBuilder().WithItems(items);
        Assert.Equal(builder.TestPrice.Amount, order.TotalAmount());
    }

    [Fact]
    public void IsCorrectGiven3Items()
    {
        var builder = new OrderBuilder();
        var order = builder.WithDefaultValues();

        Assert.Equal(builder.TestPrice.Amount * builder.TestQuantity, order.TotalAmount());
    }
}
