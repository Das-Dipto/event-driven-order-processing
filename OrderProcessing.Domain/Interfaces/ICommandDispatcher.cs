namespace OrderProcessing.Application.Interfaces;

public interface ICommandDispatcher
{
    void Dispatch<TCommand>(TCommand command);
}
