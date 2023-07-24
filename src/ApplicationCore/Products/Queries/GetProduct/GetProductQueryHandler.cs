using ApplicationCore.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.ProductAggregate;
using Domain.ProductAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Products.Queries.GetProduct;

public sealed class GetProductQueryHandler : IRequestHandler<GetProductQuery, ErrorOr<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetProductQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductByIdAsync(ProductId.Create(Guid.Parse(request.Id)));

        if (product is null)
        {
            return Errors.Product.NotFound;
        }

        return product;
    }
}
