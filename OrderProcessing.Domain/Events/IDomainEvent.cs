namespace OrderProcessing.Domain.Events;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
