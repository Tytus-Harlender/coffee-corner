using CoffeeCorner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeCorner.Infrastructure.Persistence.EntitiesConfiguration;

public class CharacteristicValueConfiguration : IEntityTypeConfiguration<CharacteristicValue>
{
    public void Configure(EntityTypeBuilder<CharacteristicValue> builder)
    {
        builder.ToTable("CharacteristicValues");
        builder.HasKey(cv => cv.Id);
        builder.Property(cv => cv.Value)
            .IsRequired();

        builder.HasOne(cv => cv.Characteristic)
            .WithMany(c => c.CharacteristicValues)
            .HasForeignKey("CharacteristicId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}