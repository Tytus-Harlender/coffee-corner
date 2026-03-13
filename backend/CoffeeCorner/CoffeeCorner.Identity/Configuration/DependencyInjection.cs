using CoffeeCorner.Identity.Interfaces;
using CoffeeCorner.Identity.Persistence;
using CoffeeCorner.Identity.Persistence.Entities;
using CoffeeCorner.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeCorner.Identity.Configuration;

public static class DependencyInjection
{
    public static void AddIdentityModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<IdentityOptions>(
            configuration.GetSection("Identity"));

        services.AddDbContext<AuthDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
            })
            .AddRoles<IdentityRole<int>>()
            .AddEntityFrameworkStores<AuthDbContext>();

        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IRefreshTokenStore, RefreshTokenStore>();
    }
}