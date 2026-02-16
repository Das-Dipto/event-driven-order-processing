using Microsoft.Extensions.DependencyInjection;

// Application interfaces
using OrderProcessing.Application.Interfaces;

// Infrastructure classes
using OrderProcessing.Infrastructure.Stores;
using OrderProcessing.Infrastructure.Dispatchers;
using OrderProcessing.Infrastructure.Publishers;

namespace OrderProcessing.Infrastructure.Wiring;

//Command Handlers
using OrderProcessing.Application.Handlers;


// Application Saga
using OrderProcessing.Application.Sagas;

public static class ApplicationBootstrapper
{
    public static ServiceProvider Build()
    {
        var services = new ServiceCollection();

        // In-memory store
        services.AddSingleton<InMemoryOrderStore>();

        // Command Dispatcher
        services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();

        // Event Publisher
        services.AddSingleton<IEventPublisher, InMemoryEventPublisher>();

        // Saga
        services.AddSingleton<OrderProcessing.Application.Sagas.OrderProcessingSaga>();

        //Command Handlers
        services.AddSingleton<OrderCommandHandlers>();


        return services.BuildServiceProvider();
    }
}
