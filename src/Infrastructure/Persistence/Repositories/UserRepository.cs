using ApplicationCore.Common.Interfaces.Persistence;
using Domain.UserAggregate;
using Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByIdAsync(UserId id)
    {
        return await _context
            .Users
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context
            .Users
            .FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context
            .Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<int> AddAsync(User user)
    {
        _context.Users.Add(user);
        return await _context.SaveChangesAsync();
    }
}
