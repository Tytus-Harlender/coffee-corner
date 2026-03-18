using CoffeeCorner.Orders.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeCorner.Orders.Infrastructure.EntitiesConfigurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems", OrdersSchema.Schema);
        builder.HasKey(oi => oi.Id);
        
        builder.Property(oi => oi.ProductId)
            .IsRequired();
        builder.Property(oi => oi.OrderId)
            .IsRequired();
        
        builder.HasIndex(oi => oi.ProductId);
        builder.HasIndex(oi => oi.OrderId);
        builder.HasIndex(oi => new {oi.OrderId, oi.ProductId})
            .IsUnique();
    }
}