using OrderProcessing.Domain.Aggregates;
using OrderProcessing.Domain.Entities;
using OrderProcessing.Domain.Enums;
using OrderProcessing.Domain.Events;
using OrderProcessing.Domain.ValueObjects;
using Xunit;

namespace OrderProcessing.Domain.Tests.Aggregates;

public sealed class OrderTests
{
    private static Order CreateValidOrder()
    {
        var item = new OrderItem(
            Guid.NewGuid(),
            1,
            new Money(100, "USD"));

        return new Order(OrderId.New(), new[] { item });
    }

    [Fact]
    public void Creating_order_without_items_should_throw()
    {
        var id = OrderId.New();

        Assert.Throws<InvalidOperationException>(
            () => new Order(id, Array.Empty<OrderItem>()));
    }

    [Fact]
    public void Order_is_created_with_created_status()
    {
        var order = CreateValidOrder();

        Assert.Equal(OrderStatus.Created, order.Status);
    }

    [Fact]
    public void Order_creation_emits_order_created_event()
    {
        var order = CreateValidOrder();

        Assert.Contains(
            order.DomainEvents,
            e => e is OrderCreatedDomainEvent);
    }

    [Fact]
    public void Valid_payment_flow_transitions_correctly()
    {
        var order = CreateValidOrder();

        order.MarkPaymentInProgress();
        order.MarkPaymentSucceeded();

        Assert.Equal(OrderStatus.PaymentSucceeded, order.Status);
    }

    [Fact]
    public void Invalid_payment_transition_should_throw()
    {
        var order = CreateValidOrder();

        Assert.Throws<InvalidOperationException>(
            () => order.MarkPaymentSucceeded());
    }

    [Fact]
    public void Completing_order_emits_status_changed_event()
    {
        var order = CreateValidOrder();

        order.MarkPaymentInProgress();
        order.MarkPaymentSucceeded();
        order.MarkInventoryInProgress();
        order.Complete();

        Assert.Equal(OrderStatus.Completed, order.Status);

        Assert.Contains(
            order.DomainEvents,
            e => e is OrderStatusChangedDomainEvent);
    }

    [Fact]
    public void Terminal_state_prevents_further_changes()
    {
        var order = CreateValidOrder();

        order.MarkPaymentInProgress();
        order.MarkPaymentFailed();

        Assert.Throws<InvalidOperationException>(
            () => order.MarkInventoryInProgress());
    }
}
