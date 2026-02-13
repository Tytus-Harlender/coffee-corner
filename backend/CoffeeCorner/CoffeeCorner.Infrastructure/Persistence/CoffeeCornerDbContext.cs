using CoffeeCorner.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Persistence;

public class CoffeeCornerDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Customer> Customers  { get; set; }
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
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoffeeCornerDbContext).Assembly);
    }
}