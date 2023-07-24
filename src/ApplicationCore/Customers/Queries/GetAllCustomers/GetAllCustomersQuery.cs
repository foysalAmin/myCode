using Domain.UserAggregate.Entities;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Customers.Queries.GetAllCustomers;

public sealed record GetAllCustomersQuery() : IRequest<ErrorOr<IEnumerable<Customer>>>;
