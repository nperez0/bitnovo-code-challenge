namespace Bitnovo.Common
{
    public class ApiResponse
    {
        public ApiResponse(bool success, string statusCode, string message)
        {
            Success = success;
            StatusCode = statusCode;
            Message = message;
        }

        public bool Success { get; }
        public string StatusCode { get; }
        public string Message { get; }
    }

    public class ApiResponse<TData> : ApiResponse
    {
        public TData Data { get; }

        public ApiResponse(bool success, string statusCode, string message, TData data)
            : base(success, statusCode, message)
        {
            Data = data;
        }
    }
}
