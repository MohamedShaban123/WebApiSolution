namespace WebApi.Errors
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public List<ApiError>? Errors { get; set; }
        public T? Data { get; set; }
    }
}
