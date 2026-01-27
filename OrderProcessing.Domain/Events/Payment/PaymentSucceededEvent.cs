using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Application.Events;

public sealed class PaymentSucceededEvent
{
    public OrderId OrderId { get; }

    public PaymentSucceededEvent(OrderId orderId)
    {
        OrderId = orderId;
    }
}
