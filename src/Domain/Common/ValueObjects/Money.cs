using Domain.Common.Models;

namespace Domain.Common.ValueObjects;

public class Money : ValueObject
{
    private Money(
        string currency,
        decimal amount)
    {
        Currency = currency;
        Amount = amount;
    }

    public string Currency { get; private set; }
    public decimal Amount { get; private set; }

    public static Money Create(
        string currency,
        decimal amount)
    {
        return new(
            currency,
            amount);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Currency;
        yield return Amount;
    }

#pragma warning disable CS8618
    private Money()
    {
    }
#pragma warning restore CS8618
}
