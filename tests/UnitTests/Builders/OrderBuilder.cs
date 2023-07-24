using Domain.Common.ValueObjects;
using Domain.OrderAggregate;
using Domain.OrderAggregate.Eitities;
using Domain.OrderAggregate.ValueObjects;
using Domain.ProductAggregate.ValueObjects;
using Domain.UserAggregate.ValueObjects;

namespace UnitTests.Builders;

public class OrderBuilder
{
    private readonly AddressBuilder _address;

    private Order _order;
    public OrderId TestOrderId => OrderId.CreateUnique();
    public CustomerId TestCustomerId => CustomerId.Create(Guid.Parse("3c73dd92-6a5d-445d-823e-3d635ad4cde5"));
    public ProductId TestProductId => ProductId.CreateUnique();
    public Money TestPrice => Money.Create("USD", 1.23m);
    public int TestQuantity => 3;
    public string TestEmail => "test@example.com";
    public PaymentRef TestPaymentRef => PaymentRef.Create("25cdcd62-ee03-4d10-9999-f3343d16cba9");

    public OrderBuilder()
    {
        _address = new AddressBuilder();
        _order = WithDefaultValues();
    }

    public Order Build()
    {
        return _order;
    }

    public Order WithDefaultValues()
    {
        _order = Order.Create(
            TestEmail,
            _address.TestPhoneNumber,
            _address.TestStreet,
            _address.TestCity,
            _address.TestState,
            _address.TestZipCode,
            _address.TestCountry,
            TestPaymentRef.Value,
            TestCustomerId);

        _order.AddItem(TestProductId, TestPrice, TestQuantity);

        return _order;
    }

    public Order WithNoItems()
    {
        _order = Order.Create(
            TestEmail,
            _address.TestPhoneNumber,
            _address.TestStreet,
            _address.TestCity,
            _address.TestState,
            _address.TestZipCode,
            _address.TestCountry,
            TestPaymentRef.Value,
            TestCustomerId);
        return _order;
    }

    public Order WithItems(List<Item> items)
    {
        _order = Order.Create(
            TestEmail,
            _address.TestPhoneNumber,
            _address.TestStreet,
            _address.TestCity,
            _address.TestState,
            _address.TestZipCode,
            _address.TestCountry,
            TestPaymentRef.Value,
            TestCustomerId);

        foreach (Item item in items)
        {
            _order.AddItem(item.ProductId, item.Price, item.Qty);
        }

        return _order;
    }
}
