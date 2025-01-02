namespace Basket.API.Basket.GetBasketByUsername
{
    public record GetBasketResponse(ShoppingCart ShoppingCart);

    public class GetBasketByUsernameEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
            {
                var result = await sender.Send(new GetBasketQuery(userName));
                var response = result.Adapt<GetBasketResponse>();
                return Results.Ok(response);
            }).WithName("GetBasket")
             .Produces<GetBasketResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Get Basket")
             .WithDescription("Get Basket");
        }
    }
}