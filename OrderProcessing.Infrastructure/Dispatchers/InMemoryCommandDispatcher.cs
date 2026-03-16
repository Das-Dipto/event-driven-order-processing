using System;

using OrderProcessing.Application.Commands;
using OrderProcessing.Application.Handlers;
using OrderProcessing.Application.Interfaces;

using OrderProcessing.Domain.Aggregates;

using OrderProcessing.Infrastructure.Stores;

namespace OrderProcessing.Infrastructure.Dispatchers;

public sealed class InMemoryCommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryCommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Dispatch<TCommand>(TCommand command)
    {
        var orderStore = (InMemoryOrderStore)_serviceProvider.GetService(typeof(InMemoryOrderStore))!;
        var eventPublisher = (IEventPublisher)_serviceProvider.GetService(typeof(IEventPublisher))!;

        if (command is ProcessPaymentCommand payment)
        {
            var order = orderStore.Get(payment.OrderId);
            var handler = new OrderCommandHandlers(order, eventPublisher);
            handler.Handle(payment);
            return;
        }

        if (command is ReserveInventoryCommand inventory)
        {
            var order = orderStore.Get(inventory.OrderId);
            var handler = new OrderCommandHandlers(order, eventPublisher);
            handler.Handle(inventory);
            return;
        }

        if (command is CompleteOrderCommand complete)
        {
            var order = orderStore.Get(complete.OrderId);
            var handler = new OrderCommandHandlers(order, eventPublisher);
            handler.Handle(complete);
            return;
        }

        throw new InvalidOperationException($"No handler for {typeof(TCommand).Name}");
    }
}