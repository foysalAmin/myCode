using Domain.ProductAggregate;
using Domain.ProductAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ProductId.Create(value));

        builder.Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(512);

        builder.OwnsOne(o => o.Price, a =>
        {
            a.WithOwner();

            a.Property(a => a.Currency)
                .HasMaxLength(30)
                .IsRequired();

            a.Property(a => a.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        });

        builder.Navigation(p => p.Price);
    }
}
