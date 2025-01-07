using BuildingBlocks.Exceptions.Handler;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Ordering.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCarter(null, config =>
            {
                var moduleTypes = typeof(Program).Assembly.GetTypes()
                  .Where(t => typeof(ICarterModule).IsAssignableFrom(t) && !t.IsAbstract);
                config.WithModules(moduleTypes.ToArray());
            });
            services.AddExceptionHandler<CustomExceptionHandler>();
            services.AddHealthChecks().AddSqlServer(configuration.GetConnectionString("MssqlConnection")!);

            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            app.MapCarter();
            app.UseExceptionHandler(options => { });
            app.UseHealthChecks("/health",
                new HealthCheckOptions
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

            return app;
        }
    }
}