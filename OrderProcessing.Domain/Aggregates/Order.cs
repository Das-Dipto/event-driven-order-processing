using OrderProcessing.Domain.Common;
using OrderProcessing.Domain.Entities;
using OrderProcessing.Domain.Enums;
using OrderProcessing.Domain.Events;
using OrderProcessing.Domain.ValueObjects;

namespace OrderProcessing.Domain.Aggregates;

public sealed class Order : AggregateRoot
{
    private readonly List<OrderItem> _items = [];

    public OrderId Id { get; }
    public OrderStatus Status { get; private set; }
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public Order(OrderId id, IEnumerable<OrderItem> items)
    {
        if (items is null)
            throw new ArgumentNullException(nameof(items));

        _items.AddRange(items);

        if (_items.Count == 0)
            throw new InvalidOperationException("Order must contain at least one item.");

        Id = id;
        Status = OrderStatus.Created;

        AddDomainEvent(new OrderCreatedDomainEvent(Id));
    }

    private void ChangeStatus(OrderStatus newStatus)
    {
        var oldStatus = Status;
        Status = newStatus;

        AddDomainEvent(
            new OrderStatusChangedDomainEvent(Id, oldStatus, newStatus));
    }

    private void EnsureNotTerminal()
    {
        if (Status is OrderStatus.PaymentFailed
            or OrderStatus.InventoryFailed
            or OrderStatus.Completed)
        {
            throw new InvalidOperationException(
                $"Order is in terminal state: {Status}");
        }
    }

    public void MarkPaymentInProgress()
    {
        EnsureNotTerminal();

        if (Status != OrderStatus.Created)
            throw new InvalidOperationException(
                "Payment can only start from Created state.");

        ChangeStatus(OrderStatus.PaymentInProgress);
    }

    public void MarkPaymentSucceeded()
    {
        if (Status != OrderStatus.PaymentInProgress)
            throw new InvalidOperationException(
                "Payment can only succeed from PaymentInProgress.");

        ChangeStatus(OrderStatus.PaymentSucceeded);
    }

    public void MarkPaymentFailed()
    {
        if (Status != OrderStatus.PaymentInProgress)
            throw new InvalidOperationException(
                "Payment can only fail from PaymentInProgress.");

        ChangeStatus(OrderStatus.PaymentFailed);
    }

    public void MarkInventoryInProgress()
    {
        EnsureNotTerminal();

        if (Status != OrderStatus.PaymentSucceeded)
            throw new InvalidOperationException(
                "Inventory can only start after payment success.");

        ChangeStatus(OrderStatus.InventoryInProgress);
    }

    public void MarkInventoryFailed()
    {
        if (Status != OrderStatus.InventoryInProgress)
            throw new InvalidOperationException(
                "Inventory can only fail from InventoryInProgress.");

        ChangeStatus(OrderStatus.InventoryFailed);
    }

    public void Complete()
    {
        if (Status != OrderStatus.InventoryInProgress)
            throw new InvalidOperationException(
                "Order can only complete after inventory processing.");

        ChangeStatus(OrderStatus.Completed);
    }
}
