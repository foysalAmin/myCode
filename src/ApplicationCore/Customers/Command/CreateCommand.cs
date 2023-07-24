using ApplicationCore.Common.Shared;
using ApplicationCore.Customers.Common;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Customers.Command;

public sealed record CreateCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    AddressCommand Address) : IRequest<ErrorOr<CustomerResult>>;
