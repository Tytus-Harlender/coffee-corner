using CoffeeCorner.Customers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeCorner.Customers.Infrastructure.EntitiesConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers", CustomersSchema.Schema);

        builder.HasKey(c => c.Id);

        builder.HasIndex(c => c.PublicId)
            .IsUnique();

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Surname)
            .IsRequired()
            .HasMaxLength(100);
    }
}