using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.OrderAggregate.Eitities;
using Domain.OrderAggregate.ValueObjects;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using UnitTests.Builders;
using Xunit;

namespace IntegrationTests.Repositories.OrderRepositoryTests;

public class GetByIdWithItemsAsync
{
    private readonly AppDbContext _context;
    private readonly OrderRepository _orderRepository;
    private OrderBuilder OrderBuilder { get; } = new OrderBuilder();

    public GetByIdWithItemsAsync()
    {
        var dbOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestCatalog")
            .Options;
        _context = new AppDbContext(dbOptions);
        _orderRepository = new OrderRepository(_context);
    }

    [Fact]
    public async Task GetOrderAndItemsByOrderIdWhenMultipleOrdersPresent()
    {
        // Arrange
        var firstOrder = OrderBuilder.WithDefaultValues();
        _context.Orders.Add(firstOrder);
        OrderId firstOrderId = firstOrder.Id;

        var secondOrderItems = new List<Item>();
        secondOrderItems.Add(Item.Create(
                OrderBuilder.TestOrderId,
                OrderBuilder.TestProductId,
                OrderBuilder.TestPrice,
                2));
        secondOrderItems.Add(Item.Create(
                OrderBuilder.TestOrderId,
                OrderBuilder.TestProductId,
                OrderBuilder.TestPrice,
                1));
        var secondOrder = OrderBuilder.WithItems(secondOrderItems);
        _context.Orders.Add(secondOrder);
        OrderId secondOrderId = secondOrder.Id;

        await _context.SaveChangesAsync();

        // Act

        // Assert
    }
}
