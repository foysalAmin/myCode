using Domain.Common.Models;

namespace Domain.ProductAggregate.ValueObjects;

public sealed class ProductId : ValueObject
{
    private ProductId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }

    public static ProductId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ProductId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private ProductId()
    {
    }
#pragma warning restore CS8618
}
