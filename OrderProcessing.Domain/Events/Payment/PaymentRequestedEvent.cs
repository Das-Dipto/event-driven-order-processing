using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Application.Events;

public sealed class PaymentRequestedEvent
{
    public OrderId OrderId { get; }

    public PaymentRequestedEvent(OrderId orderId)
    {
        OrderId = orderId;
    }
}
