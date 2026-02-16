using OrderProcessing.Application.Interfaces;

namespace OrderProcessing.Infrastructure.Publishers;

public sealed class InMemoryEventPublisher : IEventPublisher
{
    public void Publish<TEvent>(TEvent @event)
    {
        // For now, do nothing.
        // Event publishing logic will be implemented later.
    }
}
