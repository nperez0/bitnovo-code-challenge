using System.Net;

namespace Bitnovo.Common
{
    public static class ApiResponseExtensions
    {
        public static ApiResponse<T> ToApiResponse<T>(this Result<T> result)
            =>  result.IsFailure
                ? new ApiResponse<T>(false, HttpStatusCode.BadRequest.ToString(), result.Error, result.Value)
                : new ApiResponse<T>(false, HttpStatusCode.OK.ToString(), string.Empty, result.Value);
    }
}
