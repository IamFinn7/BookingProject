namespace Shared.Responses
{
    public class SuccessResponse
    {
        public int status { get; set; }
        public string message { get; set; }
    }

    public class SuccessOptionResponse : SuccessResponse
    {
        public Option option { get; set; }
    }

    public class SuccessCommandResponse<T> : SuccessResponse
    {
        public T metadata { get; set; }
    }

    public class SuccessQueryResponse<T> : SuccessOptionResponse
    {
        public T metadata { get; set; }
    }

    public class ErrorResponse
    {
        public int status { get; set; }
        public string message { get; set; }
    }
}
