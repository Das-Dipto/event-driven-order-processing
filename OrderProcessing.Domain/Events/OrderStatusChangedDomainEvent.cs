using OrderProcessing.Domain.Enums;
using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Domain.Events;

public sealed class OrderStatusChangedDomainEvent : IDomainEvent
{
    public OrderId OrderId { get; }
    public OrderStatus OldStatus { get; }
    public OrderStatus NewStatus { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public OrderStatusChangedDomainEvent(
        OrderId orderId,
        OrderStatus oldStatus,
        OrderStatus newStatus)
    {
        OrderId = orderId;
        OldStatus = oldStatus;
        NewStatus = newStatus;
    }
}
