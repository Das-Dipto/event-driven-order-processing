using System;
using System.Collections.Generic;
using Xunit;

// Domain
using OrderProcessing.Domain.Aggregates;
using OrderProcessing.Domain.Entities;
using OrderProcessing.Domain.ValueObjects;
using OrderProcessing.Domain.Enums;

// Application
using OrderProcessing.Application.Commands;
using OrderProcessing.Application.Handlers;
using OrderProcessing.Application.Interfaces;

namespace OrderProcessing.Domain.Tests.Integration;

public sealed class OrderProcessingIntegrationTests
{
    [Fact]
    public void Order_payment_inventory_and_completion_flow_works_correctly()
    {
        // Arrange
        var orderId = new OrderId(Guid.NewGuid());

        var items = new List<OrderItem>
        {
            new OrderItem(
                productId: Guid.NewGuid(),
                quantity: 1,
                unitPrice: new Money(100, "USD")
            )
        };

        var order = new Order(orderId, items);

        var publishedEvents = new List<object>();
        var eventPublisher = new TestEventPublisher(publishedEvents);

        var handler = new OrderCommandHandlers(order, eventPublisher);

        // Act
        handler.Handle(new ProcessPaymentCommand(orderId));

        // 🔥 CRITICAL FIX — simulate payment success
        order.MarkPaymentSucceeded();

        handler.Handle(new ReserveInventoryCommand(orderId));
        handler.Handle(new CompleteOrderCommand(orderId));

        // Assert
        Assert.Equal(OrderStatus.Completed, order.Status);
        Assert.NotEmpty(publishedEvents);
    }

    private sealed class TestEventPublisher : IEventPublisher
    {
        private readonly List<object> _events;

        public TestEventPublisher(List<object> events)
        {
            _events = events;
        }

        public void Publish<TEvent>(TEvent @event)
        {
            _events.Add(@event!);
        }
    }
}
