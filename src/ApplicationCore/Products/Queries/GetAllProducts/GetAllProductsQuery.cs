using Domain.ProductAggregate;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Products.Queries.GetAllProducts;

public sealed record GetAllProductsQuery() : IRequest<ErrorOr<IEnumerable<Product>>>;
