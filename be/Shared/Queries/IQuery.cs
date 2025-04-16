using MediatR;

namespace Shared.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult> { }
}
