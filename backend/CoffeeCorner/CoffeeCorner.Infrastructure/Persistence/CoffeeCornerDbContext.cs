using CoffeeCorner.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Persistence;

public class CoffeeCornerDbContext(DbContextOptions<CoffeeCornerDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Characteristic> Characteristics { get; set; }
    public DbSet<CharacteristicValue> CharacteristicValues { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoffeeCornerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}