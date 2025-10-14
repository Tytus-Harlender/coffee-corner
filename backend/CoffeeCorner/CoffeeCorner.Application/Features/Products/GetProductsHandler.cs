using MediatR;

namespace CoffeeCorner.Application.Features.Products;

public class GetProductsHandler : IRequestHandler<GetProductsCommand, object>
{
    public Task<object> Handle(GetProductsCommand request, CancellationToken cancellationToken)
    {
        var result = (object) new { Reponse = "GoldBeans, GreatTaste, AnotherProduct" };
        return Task.FromResult(result);
    }
}
