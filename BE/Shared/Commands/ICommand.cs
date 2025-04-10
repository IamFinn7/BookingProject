using MediatR;

namespace Shared.Commands
{
    public interface ICommand<out TResult> : IRequest<TResult> { }

    public interface ICommand : IRequest { }
}