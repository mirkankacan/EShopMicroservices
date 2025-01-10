namespace Shopping.Web.Pages
{
    public class CartModel(IBasketService basketService, ILogger<CartModel> logger) : PageModel
    {
        public ShoppingCartModel Cart { get; set; } = new ShoppingCartModel();

        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await basketService.LoadUserBasketAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(Guid productId)
        {
            logger.LogInformation("Remove to cart button clicked");
            Cart = await basketService.LoadUserBasketAsync();
            Cart.Items.RemoveAll(x => x.ProductId == productId);
            await basketService.StoreBasketAsync(new StoreBasketRequest(Cart));
            return RedirectToPage();
        }
    }
}