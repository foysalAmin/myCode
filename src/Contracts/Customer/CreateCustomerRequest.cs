namespace Contracts.Customer;

public record CreateCustomerRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    CreateCustomerAddressRequest Address);

public record CreateCustomerAddressRequest(
    string PhoneNumber,
    string Street,
    string City,
    string State,
    string ZipCode,
    string Country);
