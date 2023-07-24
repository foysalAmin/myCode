namespace Contracts.Order;

public sealed record OrderResponse(
    string OrderId,
    string PaymentRef,
    string CustomerId,
    string Email,
    ShipToAddressResponse ShipToAddress,
    List<ItemResponse> Items,
    string Total,
    DateTime CreatedAt);

public sealed record ShipToAddressResponse(
    string PhoneNumber,
    string Street,
    string City,
    string State,
    string Country,
    string ZipCode);

public sealed record ItemResponse(
    string ItemId,
    string ProductId,
    string Currency,
    decimal Amount,
    int Qty);
