namespace Shopping.Web.Models.Basket
{
    public class BasketCheckoutModel
    {
        public string UserName { get; set; } = default!;
        public Guid CustomerId { get; set; } = default!;
        public decimal TotalPrice { get; set; } = default!;

        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string EmailAddress { get; set; } = default!;
        public string AddressLine1 { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string City { get; set; } = default!;

        public string CardHolderName { get; set; } = default!;
        public string CardNumber { get; set; } = default!;
        public string Expiration { get; set; } = default!;
        public string Cvv { get; set; } = default!;
        public int PaymentMethod { get; set; } = default!;
    }

    // Wrapper classes
    public record CheckoutBasketRequest(BasketCheckoutModel BasketCheckout);
    public record CheckoutBasketResponse(bool IsSuccess);
}