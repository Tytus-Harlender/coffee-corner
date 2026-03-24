namespace CoffeeCorner.Identity.Interfaces.Models;

public record RegisterRequest(
    string Name,
    string Surname,
    string Email,
    string Password);