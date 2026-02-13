using CoffeeCorner.Identity.Interfaces;
using CoffeeCorner.Identity.Persistence;
using CoffeeCorner.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeCorner.Identity.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<IdentityOptions>(
            configuration.GetSection("Identity"));

        services.AddDbContext<IdentityDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddIdentityCore<IdentityUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityDbContext>();

        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IRefreshTokenStore, RefreshTokenStore>();

        return services;
    }
}