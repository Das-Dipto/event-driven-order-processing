using OrderProcessing.Domain.Aggregates;
using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Infrastructure.Stores;

public sealed class InMemoryOrderStore
{
    private readonly Dictionary<OrderId, Order> _orders = new();

    public void Save(Order order)
    {
        _orders[order.Id] = order;
    }

    public Order Get(OrderId orderId)
    {
        if (!_orders.TryGetValue(orderId, out var order))
            throw new InvalidOperationException("Order not found");

        return order;
    }
}
