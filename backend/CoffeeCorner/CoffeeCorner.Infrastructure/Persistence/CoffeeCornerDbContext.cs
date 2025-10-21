using CoffeeCorner.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Persistence;

public class CoffeeCornerDbContext(DbContextOptions<CoffeeCornerDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoffeeCornerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}