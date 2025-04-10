namespace Shared.Constants
{
    public enum ResponseCode
    {
        SUCCESS = 200,
        DELETE_SUCCESS = 200,
        UPDATED_SUCCESS = 200,
        CREATED_SUCCESS = 202,
    }

    public static class ResponseCodeExtensions
    {
        public static string GetMessage(this ResponseCode code)
        {
            return code.ToString();
        }

        public static int GetCode(this ResponseCode code)
        {
            return (int)code;
        }
    }
}
