namespace Contracts.Product;

public sealed record CreateProductRequest(
    string Name,
    string Description,
    string Currency,
    decimal Price);
