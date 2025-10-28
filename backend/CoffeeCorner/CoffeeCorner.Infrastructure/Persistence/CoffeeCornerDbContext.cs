using CoffeeCorner.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Persistence;

public class CoffeeCornerDbContext(DbContextOptions<CoffeeCornerDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Characteristic> Characteristics { get; set; }
    public DbSet<CharacteristicValue> CharacteristicValues { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoffeeCornerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}