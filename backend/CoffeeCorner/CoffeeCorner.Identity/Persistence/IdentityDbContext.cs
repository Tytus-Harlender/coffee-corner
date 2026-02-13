using CoffeeCorner.Identity.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Identity.Persistence;

public class IdentityDbContext(DbContextOptions<IdentityDbContext> options)
    : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>(options)
{
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
        builder.HasDefaultSchema("identity");
    }
}