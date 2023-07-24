namespace ApplicationCore.Common.Shared;

public sealed record AddressCommand(
    string PhoneNumber,
    string Street,
    string City,
    string State,
    string ZipCode,
    string Country);
