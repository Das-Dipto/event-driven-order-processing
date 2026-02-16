using OrderProcessing.Application.Interfaces;

namespace OrderProcessing.Infrastructure.Dispatchers;

public sealed class InMemoryCommandDispatcher : ICommandDispatcher
{
    public void Dispatch<TCommand>(TCommand command)
    {
        throw new NotImplementedException(
            "Command dispatching will be implemented in a later step.");
    }
}
