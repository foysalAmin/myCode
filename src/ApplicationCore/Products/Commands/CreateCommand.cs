using Domain.ProductAggregate;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Products.Commands;

public sealed record CreateCommand(
    string Name,
    string Description,
    string Currency,
    decimal Price) : IRequest<ErrorOr<Product>>;
