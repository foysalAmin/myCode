using ApplicationCore.Common.Interfaces.Persistence;
using Domain.UserAggregate.Entities;
using Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public sealed class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Customer?> GetCustomerByIdAsync(CustomerId id)
    {
        return await _context
            .Customers
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Customer?> GetCustomerByUserIdAsync(UserId userId)
    {
        return await _context
            .Customers
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _context
            .Customers
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<int> AddAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        return await _context.SaveChangesAsync();
    }
}
