using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Application.Commands;

public sealed class ProcessPaymentCommand
{
    public OrderId OrderId { get; }

    public ProcessPaymentCommand(OrderId orderId)
    {
        OrderId = orderId;
    }
}
