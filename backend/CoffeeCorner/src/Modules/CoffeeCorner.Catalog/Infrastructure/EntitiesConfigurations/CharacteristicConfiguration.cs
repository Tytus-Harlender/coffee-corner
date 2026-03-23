using CoffeeCorner.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeCorner.Catalog.Infrastructure.EntitiesConfigurations;

public class CharacteristicConfiguration : IEntityTypeConfiguration<Characteristic>
{
    public void Configure(EntityTypeBuilder<Characteristic> builder)
    {
        builder.ToTable("Characteristics", CatalogSchema.Schema);
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired();
    }
}