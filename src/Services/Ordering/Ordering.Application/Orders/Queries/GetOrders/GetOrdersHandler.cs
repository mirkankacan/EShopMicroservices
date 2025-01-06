using BuildingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders
{
    internal class GetOrdersQueryHandler(IOrderingDbContext dbContext) : IQueryHandler<GetOrdersQuery, GetOrdersResult>
    {
        public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            var totalCount = await dbContext.Orders.LongCountAsync(cancellationToken);
            var skip = query.PaginationRequest.PageSize * query.PaginationRequest.PageIndex;
            var orders = await dbContext.Orders
                .Include(x => x.OrderItems)
                .Take(skip..query.PaginationRequest.PageSize)
                .OrderBy(x => x.OrderName.Value)
                .ToListAsync(cancellationToken);

            //var orders = await dbContext.Orders
            //   .Include(x => x.OrderItems)
            //   .Skip(query.PaginationRequest.PageSize * query.PaginationRequest.PageIndex)
            //   .Take(query.PaginationRequest.PageSize)
            //   .OrderBy(x => x.OrderName.Value)
            //   .ToListAsync(cancellationToken);

            return new GetOrdersResult(new PaginatedResult<OrderDto>(query.PaginationRequest.PageIndex, query.PaginationRequest.PageSize, totalCount, orders.ToOrderDtoList()));
        }
    }
}