using Domain.Common.Models;

namespace Domain.OrderAggregate.ValueObjects;

public class OrderId : ValueObject
{
    private OrderId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static OrderId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static OrderId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private OrderId()
    {
    }
#pragma warning restore CS8618
}
