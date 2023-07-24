using Domain.UserAggregate;
using Domain.UserAggregate.ValueObjects;

namespace ApplicationCore.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(UserId id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<int> AddAsync(User user);
}
