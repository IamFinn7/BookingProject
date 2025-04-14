namespace Shared.Constants
{
    public static class ResponseCode
    {
        public const int OK = 200;
        public const int BadRequest = 400;
        public const int Unauthorized = 401;
        public const int Forbidden = 403;
        public const int NotFound = 404;
        public const int Conflict = 409;
        public const int InternalServerError = 500;

        public static string GetMessage(this int code) =>
            code switch
            {
                OK => "SUCCESS",
                BadRequest => "BAD_REQUEST",
                Unauthorized => "UNAUTHORIZED",
                Forbidden => "FORBIDDEN",
                NotFound => "NOT_FOUND",
                Conflict => "CONFLICT",
                InternalServerError => "INTERNAL_SERVER_ERROR",
                _ => "UNKNOWN",
            };
    }
}
