namespace Shared.Exceptions
{
    public abstract class BaseException : Exception
    {
        public virtual int StatusCode { get; } = 500;

        protected BaseException(string message)
            : base(message) { }
    }

    public class NotFoundException : BaseException
    {
        public override int StatusCode => 404;

        public NotFoundException(string message)
            : base(message) { }
    }

    public class UnauthorizedException : BaseException
    {
        public override int StatusCode => 401;

        public UnauthorizedException(string message)
            : base(message) { }
    }

    public class BadRequestException : BaseException
    {
        public override int StatusCode => 400;

        public BadRequestException(string message)
            : base(message) { }
    }
}
