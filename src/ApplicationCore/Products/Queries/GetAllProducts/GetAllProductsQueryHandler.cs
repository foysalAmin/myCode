using ApplicationCore.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.ProductAggregate;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Products.Queries.GetAllProducts;

public sealed class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ErrorOr<IEnumerable<Product>>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<IEnumerable<Product>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = (List<Product>)await _productRepository.GetAllProductsAsync();

        return products.Count < 1
            ? Errors.Product.NotFound
            : products;
    }
}
