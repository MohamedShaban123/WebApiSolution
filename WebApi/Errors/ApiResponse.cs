namespace WebApi.Errors
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public ApiError error { get; set; }
        public T Data { get; set; }
    }
}
