using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure.Data.Extensions
{
    public static class DatabaseExtensions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateAsyncScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<OrderingDbContext>();
            dbContext.Database.MigrateAsync().GetAwaiter().GetResult();
            await SeedAsync(dbContext);
        }

        private static async Task SeedAsync(OrderingDbContext dbContext)
        {
            await SeedCustomerAsync(dbContext);
            await SeedProductAsync(dbContext);
            await SeedOrdersWithItemsAsync(dbContext);
        }

        private static async Task SeedCustomerAsync(OrderingDbContext dbContext)
        {
            if (!await dbContext.Customers.AnyAsync())
            {
                await dbContext.Customers.AddRangeAsync(InitialData.Customers);
                await dbContext.SaveChangesAsync();
            }
        }

        private static async Task SeedProductAsync(OrderingDbContext dbContext)
        {
            if (!await dbContext.Products.AnyAsync())
            {
                await dbContext.Products.AddRangeAsync(InitialData.Products);
                await dbContext.SaveChangesAsync();
            }
        }

        private static async Task SeedOrdersWithItemsAsync(OrderingDbContext dbContext)
        {
            if (!await dbContext.Orders.AnyAsync())
            {
                await dbContext.Orders.AddRangeAsync(InitialData.OrdersWithItems);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}