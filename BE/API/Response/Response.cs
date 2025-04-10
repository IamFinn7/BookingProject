namespace API.Response
{
    public abstract class Response
    {
        public int status { get; set; }

        public string message { get; set; }
    }

    public class ErrorResponse : Response { }

    public class SuccessResponse : Response { }

    public class SuccessOptionResponse : Response
    {
        public Option option { get; set; }
    }

    public class SuccessQueryResponse<T> : Response
    {
        public Option option { get; set; } = new();
        public T metadata { get; set; }
    }

    public class SuccessCommandResponse<T> : Response
    {
        public T metadata { get; set; }
    }

    public class Option
    {
        public int limit { get; set; }

        public int page { get; set; }
    }
}
