namespace Ordering.Application.Orders.Commands.CreateOrder
{
    internal class CreateOrderCommandHandler(IOrderingDbContext dbContext) : ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = CreateNewOrder(command.Order);

            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateOrderResult(order.Id.Value);
        }

        private Order CreateNewOrder(OrderDto orderDto)
        {
            var shippingAddress = Address.Of(orderDto.ShippingAddress.FirstName, orderDto.ShippingAddress.LastName, orderDto.ShippingAddress.EmailAddress, orderDto.ShippingAddress.AddressLine, orderDto.ShippingAddress.Country, orderDto.ShippingAddress.City);
            var billingAddress = Address.Of(orderDto.BillingAddress.FirstName, orderDto.BillingAddress.LastName, orderDto.BillingAddress.EmailAddress, orderDto.BillingAddress.AddressLine, orderDto.BillingAddress.Country, orderDto.BillingAddress.City);

            var newOrder = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(orderDto.CustomerId),
                OrderName.Of(orderDto.OrderName),
                shippingAddress,
                billingAddress,
                Payment.Of(orderDto.Payment.CardNumber, orderDto.Payment.CardHolderName, orderDto.Payment.Expiration, orderDto.Payment.Cvv, orderDto.Payment.PaymentMethod)
                );

            foreach (var orderItem in orderDto.OrderItems)
            {
                newOrder.Add(ProductId.Of(orderItem.ProductId), orderItem.Quantity, orderItem.Price);
            }

            return newOrder;
        }
    }
}