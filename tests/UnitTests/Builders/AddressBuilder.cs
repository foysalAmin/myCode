using Domain.Common.ValueObjects;

namespace UnitTests.Builders;

public class AddressBuilder
{
    private Address _address;
    public string TestPhoneNumber => "+545456456456";
    public string TestStreet => "123 Main St.";
    public string TestCity => "Kent";
    public string TestState => "OH";
    public string TestCountry => "USA";
    public string TestZipCode => "44240";

    public AddressBuilder()
    {
        _address = WithDefaultValues();
    }

    public Address Build()
    {
        return _address;
    }

    public Address WithDefaultValues()
    {
        _address = Address.Create(
            TestPhoneNumber,
            TestStreet,
            TestCity,
            TestState,
            TestZipCode,
            TestCountry);

        return _address;
    }
}
