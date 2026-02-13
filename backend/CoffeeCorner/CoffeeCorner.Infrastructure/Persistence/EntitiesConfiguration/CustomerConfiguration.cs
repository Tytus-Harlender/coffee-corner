using CoffeeCorner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeCorner.Infrastructure.Persistence.EntitiesConfiguration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasIndex(p => p.PublicId)
            .IsUnique();

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Surname)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .HasMany<Basket>()
            .WithOne()
            .HasForeignKey(b => b.CustomerId)
            .HasPrincipalKey(p => p.Id)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasMany<Order>()
            .WithOne()
            .HasForeignKey(o => o.CustomerId)
            .HasPrincipalKey(p => p.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}