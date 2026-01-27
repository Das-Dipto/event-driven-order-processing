using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Application.Events;

public sealed class InventoryReservedEvent
{
    public OrderId OrderId { get; }

    public InventoryReservedEvent(OrderId orderId)
    {
        OrderId = orderId;
    }
}
