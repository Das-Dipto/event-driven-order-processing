using OrderProcessing.Application.Commands;
using OrderProcessing.Application.Events;
using OrderProcessing.Application.Interfaces;

namespace OrderProcessing.Application.Sagas;

public sealed class OrderProcessingSaga
{
    private readonly ICommandDispatcher _commandDispatcher;

    public OrderProcessingSaga(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher 
            ?? throw new ArgumentNullException(nameof(commandDispatcher));
    }

    public void Handle(PaymentRequestedEvent @event)
    {
        _commandDispatcher.Dispatch(
            new ProcessPaymentCommand(@event.OrderId));
    }

    public void Handle(PaymentSucceededEvent @event)
    {
        _commandDispatcher.Dispatch(
            new ReserveInventoryCommand(@event.OrderId));
    }

    public void Handle(PaymentFailedEvent @event)
    {
        // terminal state – no further actions
    }

    public void Handle(InventoryReservedEvent @event)
    {
        _commandDispatcher.Dispatch(
            new CompleteOrderCommand(@event.OrderId));
    }

    public void Handle(InventoryReservationFailedEvent @event)
    {
        // terminal state – no further actions
    }
}
