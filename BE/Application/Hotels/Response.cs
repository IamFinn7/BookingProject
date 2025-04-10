namespace Application.Hotels
{
    public enum Response
    {
        HOTEL_NOTFOUND = 404,
    }

    public static class ResponseCodeExtensions
    {
        public static string GetMessage(this Response code)
        {
            return code.ToString();
        }

        public static int GetCode(this Response code)
        {
            return (int)code;
        }
    }
}
