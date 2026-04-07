using CoffeeCorner.Orders.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeCorner.Orders.Infrastructure.EntitiesConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders", OrdersSchema.Schema);
        builder.HasKey(o => o.Id);

        builder.Property(o => o.OrderPublicId)
            .IsRequired();
        builder.HasIndex(o => o.OrderPublicId)
            .IsUnique();
        builder.Property(o => o.CustomerId)
            .IsRequired();
        builder.HasIndex(o => o.CustomerId);
        builder.Property(o => o.Status)
            .IsRequired();
        builder.Property(o => o.CreatedAt)
            .IsRequired();
        builder.Property(o => o.TotalAmount)
            .IsRequired();
        
        builder.Property(o => o.Status)
            .HasConversion<int>();
        
        builder.HasMany(o => o.Items)
            .WithOne()
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}