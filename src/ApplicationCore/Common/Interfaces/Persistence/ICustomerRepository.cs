using Domain.UserAggregate;
using Domain.UserAggregate.Entities;
using Domain.UserAggregate.ValueObjects;

namespace ApplicationCore.Common.Interfaces.Persistence;

public interface ICustomerRepository
{
    Task<Customer?> GetCustomerByIdAsync(CustomerId id);
    Task<Customer?> GetCustomerByUserIdAsync(UserId userId);
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<int> AddAsync(Customer customer);
}
