using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocks.Messaging.MassTransit
{
    public static class Extensions
    {
        public static IServiceCollection AddMessageBroker(this IServiceCollection services, IConfiguration configuration, Assembly? assembly = null)
        {
            services.AddMassTransit(config =>
            {
                config.SetKebabCaseEndpointNameFormatter(); // -:-D-
                if (assembly != null)
                {
                    // If assembly sent, auto-register consumers
                    config.AddConsumers(assembly);

                    //config.AddSagaStateMachines(assembly);
                }
                config.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(new Uri(configuration["MessageBroker:Host"]!), host =>
                    {
                        host.Username(configuration["MessageBroker:UserName"]!);
                        host.Password(configuration["MessageBroker:Password"]!);
                    });

                    // MassTransit automatically configure the endpoints for consumers
                    configurator.ConfigureEndpoints(context);
                });
            });
            return services;
        }
    }
}