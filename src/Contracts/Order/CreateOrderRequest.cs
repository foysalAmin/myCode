namespace Contracts.Order;

public sealed record CreateOrderRequest(
    string PaymentRef,
    string CustomerId,
    string Email,
    CreateShipToAddressRequest ShipToAddress,
    List<CreateItemRequest> Items);

public sealed record CreateShipToAddressRequest(
    string PhoneNumber,
    string Street,
    string City,
    string State,
    string Country,
    string ZipCode);

public sealed record CreateItemRequest(
    string ProductId,
    string Currency,
    decimal Amount,
    int Qty);
