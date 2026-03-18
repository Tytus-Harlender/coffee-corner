using CoffeeCorner.Basket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeCorner.Basket.Infrastructure.EntitiesConfigurations;

public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
{
    public void Configure(EntityTypeBuilder<BasketItem> builder)
    {
        builder.ToTable("BasketItems", BasketSchema.Schema);
        builder.HasKey(bi => bi.Id);
        
        builder.Property(bi => bi.ProductId)
            .IsRequired();
        builder.Property(bi => bi.BasketId)
            .IsRequired();
        builder.HasIndex(bi => bi.BasketId);
        builder.HasIndex(bi => bi.ProductId);
        builder.HasIndex(bi => new { bi.BasketId, bi.ProductId })
            .IsUnique();
    }
}