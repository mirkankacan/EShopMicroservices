namespace Ordering.Application.Orders.EventHandlers
{
    internal class OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger) : INotificationHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Domain event handled: {notification.GetType().Name}");
            return Task.CompletedTask;
        }
    }
}