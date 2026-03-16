using Microsoft.Extensions.DependencyInjection;

using OrderProcessing.Application.Handlers;
using OrderProcessing.Application.Interfaces;

using OrderProcessing.Infrastructure.Dispatchers;
using OrderProcessing.Infrastructure.Publishers;
using OrderProcessing.Infrastructure.Stores;

namespace OrderProcessing.Infrastructure.Wiring;

public static class ApplicationBootstrapper
{
    public static ServiceProvider Build()
    {
        var services = new ServiceCollection();

        services.AddSingleton<InMemoryOrderStore>();

        services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();
        services.AddSingleton<IEventPublisher, InMemoryEventPublisher>();

        services.AddTransient<OrderCommandHandlers>();

        return services.BuildServiceProvider();
    }
}