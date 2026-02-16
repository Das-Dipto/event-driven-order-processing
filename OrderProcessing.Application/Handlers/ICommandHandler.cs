namespace OrderProcessing.Application.Handlers;

public interface ICommandHandler<in TCommand>
{
    void Handle(TCommand command);
}
