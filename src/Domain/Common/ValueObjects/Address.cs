using Domain.Common.Models;

namespace Domain.Common.ValueObjects;

public sealed class Address : ValueObject
{
    private Address(
        string phoneNumber,
        string street,
        string city,
        string state,
        string country,
        string zipCode)
    {
        PhoneNumber = phoneNumber;
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        Country = country;
    }

    public string PhoneNumber { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public string Country { get; private set; }

    public static Address Create(
        string phoneNumber,
        string street,
        string city,
        string state,
        string zipCode,
        string country)
    {
        return new(
            phoneNumber,
            street,
            city,
            state,
            zipCode,
            country);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return PhoneNumber;
        yield return Street;
        yield return City;
        yield return State;
        yield return ZipCode;
        yield return Country;
    }

#pragma warning disable CS8618
    private Address()
    {
    }
#pragma warning restore CS8618
}
