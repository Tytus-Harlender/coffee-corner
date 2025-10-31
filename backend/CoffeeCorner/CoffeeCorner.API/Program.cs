using CoffeeCorner.Application.Features.Products;
using CoffeeCorner.Application.Features.Users;
using CoffeeCorner.Infrastructure.Persistence;
using CoffeeCorner.Infrastructure.Persistence.Seeding;
using CoffeeCorner.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => 
{
    cfg.RegisterServicesFromAssembly(typeof(GetAllProductsQuery).Assembly);
});
builder.Services.AddDbContext<CoffeeCornerDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IProductsRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<CoffeeCornerDbContext>();

    await context.Database.MigrateAsync();
    await SeedingManager.SeedAsync(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Welcome to Coffee Corner!");

app.Run();
