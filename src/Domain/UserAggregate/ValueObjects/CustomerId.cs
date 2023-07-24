using Domain.Common.Models;

namespace Domain.UserAggregate.ValueObjects;

public sealed class CustomerId : ValueObject
{
    private CustomerId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }

    public static CustomerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static CustomerId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private CustomerId()
    {
    }
#pragma warning restore CS8618
}
