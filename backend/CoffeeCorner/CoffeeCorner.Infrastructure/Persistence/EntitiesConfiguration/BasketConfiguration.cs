using CoffeeCorner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeCorner.Infrastructure.Persistence.EntitiesConfiguration;

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.ToTable("Baskets");
        builder.HasKey(b => b.Id);

        builder.HasMany(b => b.BasketItems)
            .WithOne(bi => bi.Basket)
            .HasForeignKey("BasketId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
