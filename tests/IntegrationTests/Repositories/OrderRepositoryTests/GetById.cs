using Domain.OrderAggregate.ValueObjects;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using UnitTests.Builders;
using Xunit.Abstractions;

namespace IntegrationTests.Repositories.OrderRepositoryTests;

public class GetById
{
    private readonly AppDbContext _context;
    private readonly OrderRepository _orderRepository;
    private OrderBuilder OrderBuilder { get; } = new OrderBuilder();
    private readonly ITestOutputHelper _output;

    public GetById(ITestOutputHelper output)
    {
        _output = output;
        var dbOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestCatalog")
            .Options;
        _context = new AppDbContext(dbOptions);
        _orderRepository = new OrderRepository(_context);
    }

    [Fact]
    public async Task GetsExistingOrder()
    {
        var existingOrder = OrderBuilder.WithDefaultValues();
        _context.Orders.Add(existingOrder);
        _context.SaveChanges();
        OrderId orderId = existingOrder.Id;
        _output.WriteLine($"OrderId: {orderId.Value}");

        var orderFromRepo = await _orderRepository.GetOrderByIdAsync(orderId);
        Assert.Equal(OrderBuilder.TestCustomerId, orderFromRepo!.CustomerId);

        var firstItem = orderFromRepo.Items.FirstOrDefault();
        Assert.Equal(OrderBuilder.TestQuantity, firstItem!.Qty);
    }
}
