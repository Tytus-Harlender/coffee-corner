namespace CoffeeCorner.Identity.Interfaces.Models;

public record LoginRequest(
    string Email,
    string Password);