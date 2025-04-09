namespace Shipping.PL.Controllers
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(int statusCode, string message = null, T data = default)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
    }
}
