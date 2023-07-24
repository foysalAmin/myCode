using ErrorOr;

namespace Domain.Common.Errors;

public static partial class Errors
{
    public static class Customer
    {
        public static Error InvalidOperation => Error.Unexpected();
        public static Error NotFound => Error.NotFound(
            code: "Customer.NotFound",
            description: "Expected customer is not found.");
    }
}
