using Domain.Common.Models;

namespace Domain.OrderAggregate.ValueObjects;

public sealed class PaymentRef : ValueObject
{
    private PaymentRef(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static PaymentRef Create(string value)
    {
        return new PaymentRef(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private PaymentRef()
    {
    }
#pragma warning restore CS8618
}
