using Domain.Common.Models;

namespace Domain.UserAggregate.ValueObjects;

public sealed class UserId : ValueObject
{
    private UserId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static UserId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    internal object Create(object value)
    {
        throw new NotImplementedException();
    }

#pragma warning disable CS8618
    private UserId()
    {
    }
#pragma warning restore CS8618
}
