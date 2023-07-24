using Domain.OrderAggregate;
using Domain.OrderAggregate.ValueObjects;
using Domain.ProductAggregate.ValueObjects;
using Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        ConfigureOrdersTable(builder);
        ConfigureItemsTable(builder);
    }

    private static void ConfigureOrdersTable(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => OrderId.Create(value));

        builder.Property(p => p.Email)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.PaymentRef)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PaymentRef.Create(value))
            .IsRequired();

        builder.OwnsOne(o => o.ShipToAddress, a =>
        {
            a.WithOwner();

            a.Property(a => a.PhoneNumber)
                .HasMaxLength(30);

            a.Property(a => a.Street)
                .HasMaxLength(100);

            a.Property(a => a.City)
                .HasMaxLength(50);

            a.Property(a => a.State)
                .HasMaxLength(50);

            a.Property(a => a.ZipCode)
                .HasMaxLength(18);

            a.Property(a => a.Country)
                .HasMaxLength(50);
        });

        builder.Navigation(n => n.ShipToAddress);

        builder.Property(p => p.CustomerId)
            .HasConversion(
                id => id.Value,
                value => CustomerId.Create(value))
            .IsRequired(false);
    }

    private static void ConfigureItemsTable(EntityTypeBuilder<Order> builder)
    {
        builder.OwnsMany(p => p.Items, i =>
        {
            i.ToTable("OrderItems");

            i.HasKey(x => x.Id);

            i.Property(p => p.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ItemId.Create(value));

            i.Property(p => p.OrderId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => OrderId.Create(value))
                .IsRequired();

            i.Property(p => p.ProductId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ProductId.Create(value))
                .IsRequired(false);

            i.OwnsOne(o => o.Price, a =>
            {
                a.WithOwner();

                a.Property(a => a.Currency)
                    .HasMaxLength(30)
                    .IsRequired();

                a.Property(a => a.Amount)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
            });

            i.Navigation(p => p.Price);

            i.Property(p => p.Qty)
                .HasColumnType("int")
                .IsRequired();
        });
    }
}
