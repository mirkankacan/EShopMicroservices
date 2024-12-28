using MediatR;

namespace BuildingBlocks.CQRS
{
    // Unit is void type as MediatR

    // Method to handle a command and return void.

    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
        where TCommand : ICommand<Unit>
    {
    }

    // ICommandHandler interface is a generic interface that defines a method to handle a command and return a response.
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
        where TResponse : notnull
    {
    }
}