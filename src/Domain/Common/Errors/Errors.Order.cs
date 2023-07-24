using ErrorOr;

namespace Domain.Common.Errors;

public static partial class Errors
{
    public static class Order
    {
        public static Error InvalidOperation => Error.Unexpected();
        public static Error NotFound => Error.NotFound(
            code: "Order.NotFound",
            description: "Expected Order is not found.");
    }
}
