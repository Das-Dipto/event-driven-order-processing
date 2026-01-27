using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Application.Commands;

public sealed class CompleteOrderCommand
{
    public OrderId OrderId { get; }

    public CompleteOrderCommand(OrderId orderId)
    {
        OrderId = orderId;
    }
}
