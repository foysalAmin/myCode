using ApplicationCore.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.ProductAggregate;
using ErrorOr;
using MediatR;

namespace ApplicationCore.Products.Commands;

public sealed class CreateCommandHandler : IRequestHandler<CreateCommand, ErrorOr<Product>>
{
    private readonly IProductRepository _productRepository;

    public CreateCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<Product>> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        Product product = Product.Create(
            request.Name,
            request.Description,
            request.Currency,
            request.Price);

        return await _productRepository.AddAsync(product) < 1
            ? Errors.Product.InvalidOperation
            : product;
    }
}
