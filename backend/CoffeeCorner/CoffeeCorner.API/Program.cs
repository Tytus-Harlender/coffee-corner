using CoffeeCorner.API.Features.CoffeeTypes;
using CoffeeCorner.Application.Features.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => 
{
    cfg.RegisterServicesFromAssembly(typeof(GetProductsCommand).Assembly);
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<ICoffeeTypesService, CoffeeTypesService>();

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
