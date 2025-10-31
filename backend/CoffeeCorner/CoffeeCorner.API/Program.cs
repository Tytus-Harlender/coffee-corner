using CoffeeCorner.Application.Features.Products;
using CoffeeCorner.Application.Features.Users;
using CoffeeCorner.Infrastructure.Persistence;
using CoffeeCorner.Infrastructure.Persistence.Seeding;
using CoffeeCorner.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => 
{
    cfg.RegisterServicesFromAssembly(typeof(GetAllProductsQuery).Assembly);
});
builder.Services.AddDbContext<CoffeeCornerDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddOpenApi("v1");
builder.Services.AddScoped<IProductsRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<CoffeeCornerDbContext>();

    await context.Database.MigrateAsync();
    await SeedingManager.SeedAsync(context);

    app.MapOpenApi();

    app.UseSwaggerUI(options => {

        options.SwaggerEndpoint("https://localhost:44347/openapi/v1.json", "Openapi V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Welcome to Coffee Corner!");

app.Run();
