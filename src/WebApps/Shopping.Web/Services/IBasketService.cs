using System.Net;

namespace Shopping.Web.Services
{
    public interface IBasketService
    {
        [Get("/basket-service/basket/{userName}")]
        Task<GetBasketResponse> GetBasketAsync(string userName);

        [Post("/basket-service/basket")]
        Task<StoreBasketResponse> StoreBasketAsync(StoreBasketRequest request);

        [Delete("/basket-service/basket/{userName}")]
        Task<DeleteBasketResponse> DeleteBasketAsync(string userName);

        [Post("/basket-service/basket/checkout")]
        Task<CheckoutBasketResponse> CheckoutBasketAsync(CheckoutBasketRequest request);

        // Interface method (min .NET 8)
        public async Task<ShoppingCartModel> LoadUserBasketAsync()
        {
            // Default username
            var userName = "swn";
            ShoppingCartModel basket;
            try
            {
                var getBasketResponse = await GetBasketAsync(userName);
                basket = getBasketResponse.Cart;
            }
            catch (ApiException apiException) when (apiException.StatusCode == HttpStatusCode.NotFound)
            {
                basket = new ShoppingCartModel
                {
                    UserName = userName,
                    Items = []
                };
            }
            return basket;
        }
    }
}