using CoffeeCorner.Application.Interfaces;
using MediatR;

namespace CoffeeCorner.Application.Features.Baskets.DeleteUserBasketItems;

public class DeleteUserBasketItemsHandler(IBasketRepository basketRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserBasketItemsCommand, Unit>
{
    public async Task<Unit> Handle(DeleteUserBasketItemsCommand request, CancellationToken cancellationToken)
    {
        var basket = await basketRepository.GetUserBasketAsync(request.UserPublicId);

        if (basket == null) throw new ArgumentNullException("No basket found", nameof(basket));
    
        basket.DeleteItem(request.ProductPublicId);

        await basketRepository.UpdateBasketAsync(basket);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
