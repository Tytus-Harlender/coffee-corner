using CoffeeCorner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeCorner.Infrastructure.Persistence.EntitiesConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name)
            .IsRequired();
        builder.Property(p => p.Description)
            .IsRequired();

        builder.HasMany(p => p.Categories)
            .WithMany(c => c.Products)
            .UsingEntity<Dictionary<string, object>>(
            "ProductCategory",
            j => j.HasOne<Category>()
                    .WithMany()
                    .HasForeignKey("CategoryId")
                    .OnDelete(DeleteBehavior.Restrict),
            j => j.HasOne<Product>()
                    .WithMany()
                    .HasForeignKey("ProductId")
                    .OnDelete(DeleteBehavior.Restrict));

        builder.HasMany(p => p.CharacteristicValues)
            .WithMany(cv => cv.Products)
            .UsingEntity<Dictionary<string, object>>(
            "ProductCharacteristicValue",
            j => j.HasOne<CharacteristicValue>()
                    .WithMany()
                    .HasForeignKey("CharacteristicValueId")
                    .OnDelete(DeleteBehavior.Restrict),
            j => j.HasOne<Product>()
                    .WithMany()
                    .HasForeignKey("ProductId")
                    .OnDelete(DeleteBehavior.Restrict));
    }
}