using OrderProcessing.Application.Commands;
using OrderProcessing.Application.Interfaces;
using OrderProcessing.Domain.Aggregates;

namespace OrderProcessing.Application.Handlers;

public sealed class OrderCommandHandlers :
    ICommandHandler<ProcessPaymentCommand>,
    ICommandHandler<ReserveInventoryCommand>,
    ICommandHandler<CompleteOrderCommand>
{
    private readonly IEventPublisher _eventPublisher;

    // NOTE:
    // In real life, Order would be loaded from a repository.
    // For now, we assume it is already available.
    private readonly Order _order;

    public OrderCommandHandlers(Order order, IEventPublisher eventPublisher)
    {
        _order = order;
        _eventPublisher = eventPublisher;
    }

    public void Handle(ProcessPaymentCommand command)
    {
        _order.MarkPaymentInProgress();
        PublishDomainEvents();
    }

    public void Handle(ReserveInventoryCommand command)
    {
        _order.MarkInventoryInProgress();
        PublishDomainEvents();
    }

    public void Handle(CompleteOrderCommand command)
    {
        _order.Complete();
        PublishDomainEvents();
    }

    private void PublishDomainEvents()
    {
        foreach (var domainEvent in _order.DomainEvents)
        {
            _eventPublisher.Publish(domainEvent);
        }

        _order.ClearDomainEvents();
    }
}
