using Domain.UserAggregate.Entities;
using Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(k => k.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => CustomerId.Create(value));

        builder.Property(x => x.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value))
            .IsRequired();

        builder.OwnsOne(o => o.Address, a =>
        {
            a.WithOwner();

            a.Property(a => a.PhoneNumber)
                .HasMaxLength(30)
                .IsRequired();

            a.Property(a => a.Street)
                .HasMaxLength(100)
                .IsRequired();

            a.Property(a => a.City)
                .HasMaxLength(50)
                .IsRequired();

            a.Property(a => a.State)
                .HasMaxLength(50)
                .IsRequired();

            a.Property(a => a.ZipCode)
                .HasMaxLength(18)
                .IsRequired();

            a.Property(a => a.Country)
                .HasMaxLength(50)
                .IsRequired();
        });

        builder.Navigation(x => x.Address);

        builder.HasOne(p => p.User)
            .WithOne(p => p.Customer)
            .HasForeignKey<Customer>(fk => fk.UserId)
            .IsRequired();
    }
}
