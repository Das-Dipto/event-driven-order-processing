namespace OrderProcessing.Application.Interfaces;

public interface IEventPublisher
{
    void Publish<TEvent>(TEvent @event);
}
