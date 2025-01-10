namespace Shopping.Web.Pages
{
    public class ProductDetailModel(ICatalogService catalogService, IBasketService basketService, ILogger<ProductDetailModel> logger) : PageModel
    {
        public ProductModel Product { get; set; } = default!;

        [BindProperty]
        public string Color { get; set; } = default!;

        [BindProperty]
        public int Quantity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid productId)
        {
            var response = await catalogService.GetProductAsync(productId);
            Product = response.Product;
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
        {
            logger.LogInformation("Add to cart button clicked");
            var productResponse = await catalogService.GetProductAsync(productId);

            var basket = await basketService.LoadUserBasketAsync();

            basket.Items.Add(new ShoppingCartItemModel
            {
                ProductId = productId,
                ProductName = productResponse.Product.Name,
                Price = productResponse.Product.Price,
                Quantity = Quantity,
                Color = Color
            });

            await basketService.StoreBasketAsync(new StoreBasketRequest(basket));

            return RedirectToPage("Cart");
        }
    }
}