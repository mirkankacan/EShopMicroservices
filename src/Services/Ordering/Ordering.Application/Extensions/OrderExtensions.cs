namespace Ordering.Application.Extensions
{
    public static class OrderExtensions
    {
        public static IEnumerable<OrderDto> ToOrderDtoList(this IEnumerable<Order> orders)
        {
            return orders.Select(order => new OrderDto(
                     order.Id.Value,
                     order.CustomerId.Value,
                     order.OrderName.Value,
                     new AddressDto(
                         order.ShippingAddress.FirstName,
                         order.ShippingAddress.LastName,
                         order.ShippingAddress.EmailAddress,
                         order.ShippingAddress.AddressLine,
                         order.ShippingAddress.Country,
                         order.ShippingAddress.City),
                     new AddressDto(
                         order.BillingAddress.FirstName,
                         order.BillingAddress.LastName,
                         order.BillingAddress.EmailAddress,
                         order.BillingAddress.AddressLine,
                         order.BillingAddress.Country,
                         order.BillingAddress.City),
                     new PaymentDto(
                         order.Payment.CardHolderName,
                         order.Payment.CardNumber,
                         order.Payment.Expiration,
                         order.Payment.Cvv,
                         order.Payment.PaymentMethod),
                     order.Status,
                     order.OrderItems.Select(x => new OrderItemDto(x.OrderId.Value, x.ProductId.Value, x.Quantity, x.Price)).ToList()
                     ));
        }

        public static OrderDto ToOrderDto(this Order order)
        {
            return DtoFromOrder(order);
        }

        private static OrderDto DtoFromOrder(Order order)
        {
            return new OrderDto(
                   order.Id.Value,
                   order.CustomerId.Value,
                   order.OrderName.Value,
                   new AddressDto(
                       order.ShippingAddress.FirstName,
                       order.ShippingAddress.LastName,
                       order.ShippingAddress.EmailAddress,
                       order.ShippingAddress.AddressLine,
                       order.ShippingAddress.Country,
                       order.ShippingAddress.City),
                   new AddressDto(
                       order.BillingAddress.FirstName,
                       order.BillingAddress.LastName,
                       order.BillingAddress.EmailAddress,
                       order.BillingAddress.AddressLine,
                       order.BillingAddress.Country,
                       order.BillingAddress.City),
                   new PaymentDto(
                       order.Payment.CardHolderName,
                       order.Payment.CardNumber,
                       order.Payment.Expiration,
                       order.Payment.Cvv,
                       order.Payment.PaymentMethod),
                   order.Status,
                   order.OrderItems.Select(x => new OrderItemDto(x.OrderId.Value, x.ProductId.Value, x.Quantity, x.Price)).ToList()
                  );
        }
    }
}