namespace Ordering.Domain.ValueObjects
{
    public record Payment
    {
        public string CardNumber { get; } = default!;
        public string? CardHolderName { get; } = default!;
        public string Expiration { get; } = default!;
        public string Cvv { get; } = default!;
        public int PaymentMethod { get; } = default!;

        protected Payment() { }

        private Payment(string cardNumber, string cardHolderName, string expiration, string cvv, int paymentMethod)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            Expiration = expiration;
            Cvv = cvv;
            PaymentMethod = paymentMethod;
        }
        public static Payment Of(string cardNumber, string cardHolderName, string expiration, string cvv, int paymentMethod)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
            ArgumentException.ThrowIfNullOrWhiteSpace(cardHolderName);
            ArgumentException.ThrowIfNullOrWhiteSpace(cvv);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);
            return new Payment(cardNumber, cardHolderName, expiration, cvv, paymentMethod);
        }
    }
}