namespace Basket.API.Models
{
    public class ShoppingCart
    {
        [Identity]
        public string UserName { get; set; } = default!;

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public ShoppingCart()
        {
        }
    }
}