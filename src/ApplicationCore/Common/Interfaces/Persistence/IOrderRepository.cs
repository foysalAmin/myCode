using Domain.OrderAggregate;
using Domain.OrderAggregate.ValueObjects;
using Domain.UserAggregate.ValueObjects;

namespace ApplicationCore.Common.Interfaces.Persistence;

public interface IOrderRepository
{
    Task<Order?> GetOrderByIdAsync(OrderId id);
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(CustomerId customerId);
    Task<int> AddAsync(Order order);
}
