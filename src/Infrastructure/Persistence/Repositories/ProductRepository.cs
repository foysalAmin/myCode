using ApplicationCore.Common.Interfaces.Persistence;
using Domain.ProductAggregate;
using Domain.ProductAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public sealed class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetProductByIdAsync(ProductId id)
    {
        return await _context
            .Products
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context
            .Products
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<int> AddAsync(Product product)
    {
        _context.Products.Add(product);
        return await _context.SaveChangesAsync();
    }
}
