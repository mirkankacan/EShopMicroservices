namespace Ordering.Application.Orders.EventHandlers
{
    internal class OrderUpdatedEventHandler(ILogger<OrderUpdatedEventHandler> logger) : INotificationHandler<OrderUpdatedEvent>
    {
        public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Domain event handled: {notification.GetType().Name}");
            return Task.CompletedTask;
        }
    }
}