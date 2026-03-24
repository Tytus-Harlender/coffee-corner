using System.Reflection;
using CoffeeCorner.Basket.Domain.Entities;
using CoffeeCorner.Basket.Infrastructure.EntitiesConfigurations;
using CoffeeCorner.Catalog.Domain.Entities;
using CoffeeCorner.Catalog.Infrastructure.EntitiesConfigurations;
using CoffeeCorner.Customers;
using CoffeeCorner.Customers.Domain.Entities;
using CoffeeCorner.Customers.Infrastructure.EntitiesConfigurations;
using CoffeeCorner.Orders.Domain.Entities;
using CoffeeCorner.Orders.Infrastructure.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Persistence;

public class CoffeeCornerDbContext(DbContextOptions options)
    : DbContext(options),
        ICustomerReadDbContext
{
    public DbSet<Customer> Customers  { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Characteristic> Characteristics { get; set; }
    public DbSet<CharacteristicValue> CharacteristicValues { get; set; }
    public DbSet<Basket.Domain.Entities.Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        modelBuilder.ApplyConfiguration(new BasketConfiguration());
        modelBuilder.ApplyConfiguration(new BasketItemConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CharacteristicConfiguration());
        modelBuilder.ApplyConfiguration(new CharacteristicValueConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }
}