using BuildingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders
{
    public record class GetOrdersQuery(PaginationRequest PaginationRequest) : IQuery<GetOrdersResult>;
    public record GetOrdersResult(PaginatedResult<OrderDto> PaginatedResult);
}