using ErrorOr;

namespace Domain.Common.Errors;

public static partial class Errors
{
    public static class Product
    {
        public static Error InvalidOperation => Error.Unexpected();
        public static Error NotFound => Error.NotFound(
            code: "Product.NotFound",
            description: "Expected product is not found.");
    }
}
