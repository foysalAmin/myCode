using Domain.Common.Models;
using Domain.UserAggregate.Entities;
using Domain.UserAggregate.Enums;
using Domain.UserAggregate.ValueObjects;

namespace Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    private User(
        UserId userId,
        string firstName,
        string lastName,
        string email,
        string password,
        UserType userType) : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        UserType = userType;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public UserType UserType { get; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    // Navigation property
    public Customer? Customer { get; private set; }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password,
        UserType userType = UserType.ApplicationUser)
    {
        return new(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password,
            userType);
    }

#pragma warning disable CS8618
    private User()
    {
    }
#pragma warning restore CS8618
}
