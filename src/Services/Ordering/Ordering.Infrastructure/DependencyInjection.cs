using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MssqlConnection");

            //services.AddDbContext<OrderContext>(options =>
            //    options.UseSqlServer(connectionString));
            return services;
        }
    }
}