namespace Ordering.Application.Orders.Commands.DeleteOrder
{
    internal class DeleteOrderCommandHandler(IOrderingDbContext dbContext) : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
    {
        public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var orderId = OrderId.Of(command.OrderId);

            // Best performance to retrieve a single record by primary key
            var order = await dbContext.Orders.FindAsync([orderId], cancellationToken: cancellationToken);
            if (order == null) throw new OrderNotFoundException(command.OrderId);

            dbContext.Orders.Remove(order);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new DeleteOrderResult(true);
        }
    }
}