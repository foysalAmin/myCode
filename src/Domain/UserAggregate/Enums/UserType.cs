namespace Domain.UserAggregate.Enums;

public enum UserType
{
    /// <summary>
    /// Represents a user who will be managing the application backend.
    /// </summary>
    ApplicationUser = 1,

    /// <summary>
    /// Represents a Customer who will be buying the product.
    /// </summary>
    CustomerUser = 2,
}
