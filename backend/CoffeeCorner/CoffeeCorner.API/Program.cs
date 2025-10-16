using CoffeeCorner.API.Features.CoffeeTypes;
using CoffeeCorner.Application.Features.Products;
using CoffeeCorner.Infrastructure.Persistence;
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
    options.UseSqlServer("connection string");
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<ICoffeeTypesService, CoffeeTypesService>();
builder.Services.AddSingleton<IProductsReadRepository, ProductReadRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Welcome to Coffee Corner!");
app.MapGet("/products/types", (ICoffeeTypesService coffeeTypesService) => coffeeTypesService.GetCoffeeTypes());

app.Run();
