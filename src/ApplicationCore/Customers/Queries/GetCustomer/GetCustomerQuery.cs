using ApplicationCore.Customers.Common;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Customers.GetCustomer.Queries;

public sealed record GetCustomerQuery(string Id) : IRequest<ErrorOr<CustomerResult>>;
