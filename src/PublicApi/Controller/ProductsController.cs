using ApplicationCore.Products.Commands;
using ApplicationCore.Products.Queries.GetAllProducts;
using ApplicationCore.Products.Queries.GetProduct;
using Contracts.Product;
using Domain.ProductAggregate;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PublicApi.Controller;

[Route("[controller]")]
public class ProductsController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(string id)
    {
        ErrorOr<Product> getResult = await _mediator.Send(new GetProductQuery(id));

        return getResult.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        ErrorOr<IEnumerable<Product>> getResults = await _mediator.Send(new GetAllProductsQuery());

        return getResults.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateProductRequest request)
    {
        var command = _mapper.Map<CreateCommand>(request);

        ErrorOr<Product> createResult = await _mediator.Send(command);

        return createResult.Match(
            result => Ok(result),
            errors => Problem(errors));
    }
}
