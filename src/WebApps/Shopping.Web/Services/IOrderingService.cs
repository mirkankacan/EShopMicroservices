namespace Shopping.Web.Services
{
    public interface IOrderingService
    {
        [Get("/ordering-service/orders?pageIndex={pageIndex}&pageSize={pageSize}")]
        Task<GetOrdersResponse> GetOrdersAsync(int? pageIndex = 0, int? pageSize = 12);

        [Get("/ordering-service/orders/{orderName}")]
        Task<GetOrdersByNameResponse> GetOrdersByNameAsync(string orderName);

        [Get("/ordering-service/orders/customer/{customerId}")]
        Task<GetOrdersByCustomerResponse> GetOrdersByCustomerAsync(Guid customerId);
    }
}