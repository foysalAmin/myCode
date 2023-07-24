using ApplicationCore.Common.Interfaces.Persistence;
using Domain.OrderAggregate;
using Domain.OrderAggregate.ValueObjects;
using Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Order?> GetOrderByIdAsync(OrderId id)
    {
        return await _context
            .Orders
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _context
            .Orders
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(CustomerId customerId)
    {
        return await _context
            .Orders
            .Where(x => x.CustomerId == customerId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<int> AddAsync(Order order)
    {
        _context.Orders.Add(order);
        return await _context.SaveChangesAsync();
    }
}
