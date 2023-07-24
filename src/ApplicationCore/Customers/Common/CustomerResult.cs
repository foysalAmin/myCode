using ApplicationCore.Common.Shared;
using Domain.UserAggregate;
using Domain.UserAggregate.Entities;

namespace ApplicationCore.Customers.Common;

public record CustomerResult(
    string CustomerId,
    string UserId,
    AddressCommand Address,
    int TotalOrders,
    string? Token,
    DateTime? CreatedAt);
