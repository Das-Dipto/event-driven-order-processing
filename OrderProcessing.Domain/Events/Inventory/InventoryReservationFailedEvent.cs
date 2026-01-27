using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Application.Events;

public sealed class InventoryReservationFailedEvent
{
    public OrderId OrderId { get; }

    public InventoryReservationFailedEvent(OrderId orderId)
    {
        OrderId = orderId;
    }
}
