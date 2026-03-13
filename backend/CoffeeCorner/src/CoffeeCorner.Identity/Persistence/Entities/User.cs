using Microsoft.AspNetCore.Identity;

namespace CoffeeCorner.Identity.Persistence.Entities;

public class User : IdentityUser<int>
{
    public required Guid PublicId { get; init; }
}