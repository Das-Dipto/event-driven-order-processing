namespace OrderProcessing.Application.Interfaces;

public interface ICommandHandler<in TCommand>
{
    void Handle(TCommand command);
}
