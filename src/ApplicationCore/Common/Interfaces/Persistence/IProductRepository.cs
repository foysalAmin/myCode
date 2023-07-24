using Domain.ProductAggregate;
using Domain.ProductAggregate.ValueObjects;

namespace ApplicationCore.Common.Interfaces.Persistence;

public interface IProductRepository
{
    Task<Product?> GetProductByIdAsync(ProductId id);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<int> AddAsync(Product product);
}
