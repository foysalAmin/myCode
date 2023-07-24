using Domain.ProductAggregate;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Products.Queries.GetProduct;

public sealed record GetProductQuery(string Id) : IRequest<ErrorOr<Product>>;
