using System.Text;
using CoffeeCorner.Application.Features.Baskets;
using CoffeeCorner.Application.Features.Products;
using CoffeeCorner.Application.Features.Products.GetAllProducts;
using CoffeeCorner.Application.Features.Users;
using CoffeeCorner.Application.Interfaces;
using CoffeeCorner.Domain.Entities;
using CoffeeCorner.Infrastructure.Persistence;
using CoffeeCorner.Infrastructure.Persistence.Seeding;
using CoffeeCorner.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
            )
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddMediatR(cfg => 
{
    cfg.RegisterServicesFromAssembly(typeof(GetAllProductsQuery).Assembly);
});
builder.Services.AddDbContext<CoffeeCornerDbContext>((serviceProvider,options) =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
    }
});
builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<CoffeeCornerDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddOpenApi("v1");
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Welcome to Coffee Corner!");

app.Run();
