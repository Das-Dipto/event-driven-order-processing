using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Application.Events;

public sealed class PaymentFailedEvent
{
    public OrderId OrderId { get; }

    public PaymentFailedEvent(OrderId orderId)
    {
        OrderId = orderId;
    }
}
