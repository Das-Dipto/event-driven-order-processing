using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Application.Commands;

public sealed class ReserveInventoryCommand
{
    public OrderId OrderId { get; }

    public ReserveInventoryCommand(OrderId orderId)
    {
        OrderId = orderId;
    }
}
