namespace Ordering.Application.Dtos
{
    public record PaymentDto(
        string CardHolderName,
        string CardNumber,
        string Expiration,
        string Cvv,
        int PaymentMethod
        );
}