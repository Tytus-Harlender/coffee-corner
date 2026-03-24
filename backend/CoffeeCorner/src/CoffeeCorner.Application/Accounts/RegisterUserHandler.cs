using CoffeeCorner.Application.Abstractions.Modules.Customers;
using CoffeeCorner.Identity.Interfaces;
using CoffeeCorner.Identity.Interfaces.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoffeeCorner.Application.Accounts;

public class RegisterUserHandler(
    IIdentityService identityService,
    ICustomersModule customersModule,
    ILogger<RegisterUserHandler> logger) : IRequestHandler<RegisterUserCommand, TokenResult>
{
    public async Task<TokenResult> Handle(RegisterUserCommand request, CancellationToken ct)
    {
        try
        {
            // 1. Create Identity user
            var token = await identityService.RegisterAsync(
                request.Email,
                request.Password,
                ct);

            // 2. Ensure Customer exists (idempotent)
            var customerDto = new CustomerDto()
            {
                PublicId = token.PublicId,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname
            };

            await customersModule.EnsureCustomerExistsAsync(customerDto, ct);
            return token;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error during user registration");
            throw;
        }
    }
}