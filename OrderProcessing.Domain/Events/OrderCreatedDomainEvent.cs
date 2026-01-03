using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Domain.Events;

public sealed class OrderCreatedDomainEvent : IDomainEvent
{
    public OrderId OrderId { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public OrderCreatedDomainEvent(OrderId orderId)
    {
        OrderId = orderId;
    }
}
