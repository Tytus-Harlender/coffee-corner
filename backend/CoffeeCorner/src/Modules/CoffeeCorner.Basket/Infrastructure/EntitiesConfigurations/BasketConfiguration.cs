using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeCorner.Basket.Infrastructure.EntitiesConfigurations;

public class BasketConfiguration : IEntityTypeConfiguration<Domain.Entities.Basket>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Basket> builder)
    {
        builder.ToTable("Baskets", BasketSchema.Schema);

        builder.HasKey(b => b.Id);

        builder.Property(b => b.CustomerId)
            .IsRequired();

        // ensures one basket per customer
        builder.HasIndex(b => b.CustomerId)
            .IsUnique();

        builder.HasMany(b => b.BasketItems)
            .WithOne()
            .HasForeignKey(bi => bi.BasketId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}