namespace WebApi.Errors
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }     
        public string Message { get; set; }      
        public string? Details { get; set; }    
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public T Data { get; set; }
    }
}
