namespace Basket.API.Basket.GetBasketByUsername
{
    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart ShoppingCart);

    internal class GetBasketByUsernameQueryHandler(IBasketRepository repository) : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            var basket = await repository.GetBasketAsync(query.UserName, cancellationToken);
            return new GetBasketResult(basket);
        }
    }
}