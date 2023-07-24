using Domain.Common.Models;

namespace Domain.OrderAggregate.ValueObjects;

public sealed class ItemId : ValueObject
{
    private ItemId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }

    public static ItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ItemId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
