namespace Basket.API.Basket.DeleteBasketByUsername
{
    public record DeleteBasketResponse(bool IsSuccess);

    public class DeleteBasketByUsernameEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
            {
                var result = await sender.Send(new DeleteBasketCommand(userName));
                var response = result.Adapt<DeleteBasketResponse>();
                return Results.Ok(response);
            }).WithName("DeleteBasket")
             .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Delete Basket")
             .WithDescription("Delete Basket");
        }
    }
}