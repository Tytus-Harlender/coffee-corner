using CoffeeCorner.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeCorner.Catalog.Infrastructure.EntitiesConfigurations;

public class CharacteristicValueConfiguration : IEntityTypeConfiguration<CharacteristicValue>
{
    public void Configure(EntityTypeBuilder<CharacteristicValue> builder)
    {
        builder.ToTable("CharacteristicValues", CatalogSchema.Schema);
        builder.HasKey(cv => cv.Id);
        builder.Property(cv => cv.Value)
            .IsRequired();

        builder.HasOne(cv => cv.Characteristic)
            .WithMany(c => c.CharacteristicValues)
            .HasForeignKey(cv =>cv.CharacteristicId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}