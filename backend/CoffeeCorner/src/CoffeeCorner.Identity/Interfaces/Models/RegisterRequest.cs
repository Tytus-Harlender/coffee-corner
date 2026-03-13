namespace CoffeeCorner.Identity.Interfaces.Models;

public record RegisterRequest(
    string Email,
    string Password);