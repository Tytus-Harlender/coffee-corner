namespace CoffeeCorner.Application.Features.Users;

public class UserDto
{
    public Guid PublicId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
}
