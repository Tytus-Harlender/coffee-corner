using CoffeeCorner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeCorner.Infrastructure.Persistence.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Name)
            .IsRequired();
        builder.Property(u => u.Surname)
            .IsRequired();
        builder.Property(u => u.Email)
            .IsRequired();
        builder.Property(u => u.PasswordHash)
            .IsRequired();

        builder.HasMany(u => u.Baskets)
            .WithOne()
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Orders)
            .WithOne()
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
