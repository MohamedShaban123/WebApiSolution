using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;
using WebApi.Errors;

namespace WebApi.Middlwares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx)
            {

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new ApiResponse<string>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "This record cannot be deleted because it is referenced by other data.",
                    Errors = new List<ApiError>
                            {
                                new ApiError
                                {
                                    StatusCode = StatusCodes.Status400BadRequest,
                                    Message = "Delete constraint violation",
                                    Details = "This record is being used in another table and cannot be removed.",
                                    Date = DateTime.UtcNow
                                }
                            }
                });


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = new ApiResponse<string>
            {
                IsSuccess = false,
                Data = null,
                Message = "Exception Occured",
                Errors = new List<ApiError>
            {
                new ApiError
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal Server Error",
                    Details = ex.Message,
                    Date = DateTime.UtcNow
                }
            }
            };
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }
    }
}
