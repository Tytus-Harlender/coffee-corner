using CoffeeCorner.Application.Abstractions.Modules.Customers;
using CoffeeCorner.Customers.Application;
using CoffeeCorner.Customers.Application.Commands.CreateCustomer;
using CoffeeCorner.Customers.Application.Commands.DeleteCustomer;
using CoffeeCorner.Customers.Application.Commands.UpdateCustomer;
using CoffeeCorner.Customers.Application.Queries.GetAllCustomers;
using CoffeeCorner.Customers.Application.Queries.GetCustomer;
using CoffeeCorner.Orders;
using CoffeeCorner.Orders.Application.Queries.GetAllCustomerOrders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeCorner.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Authorize(Roles ="Admin")]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllUsers(GetAllCustomersQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{publicId:guid}")]
    [Authorize]
    public async Task<ActionResult<CustomerDto>> GetUserAsync([FromRoute] Guid publicId)
    {
        var query = new GetCustomerQuery(publicId);
        var result = await mediator.Send(query);
        return result is null ? NotFound("User not found") : Ok(result);
    }

    [HttpGet("{publicId:guid}/orders")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllUserOrdersAsync([FromRoute] Guid publicId)
    {
        var query = new GetAllCustomerOrdersQuery(publicId);
        var result = await mediator.Send(query);
        return result is null ? NotFound("Orders not found for the user") : Ok(result);
    }

    [HttpPost]
    [Authorize(Roles ="Admin")]
    public async Task<ActionResult<CustomerDto>> CreateUserAsync(CreateCustomerCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetUserAsync), new { publicId = result.PublicId }, result);
    }

    [HttpPut("{publicId:guid}")]
    [Authorize]
    public async Task<ActionResult> UpdateUserAsync(UpdateCustomerCommand command, [FromRoute] Guid publicId)
    {
        command.PublicId  = publicId;
        var result = await mediator.Send(command);
        return result is null ? BadRequest() : Ok(result);
    }

    [HttpDelete("{publicId:guid}")]
    [Authorize]
    public async Task<ActionResult> DeleteUserAsync([FromRoute] Guid publicId)
    {
        var command = new DeleteCustomerCommand(publicId);
        var result = await mediator.Send(command);
        return result is null ? BadRequest() : NoContent();
    }
}
