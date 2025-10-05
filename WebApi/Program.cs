using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Controllers;
using WebApi.Data.Context;
using WebApi.Data.Models;
using WebApi.Errors;
using WebApi.Helper;
using WebApi.Middlwares;
using WebApi.Models;
using WebApi.Repository.IRepo;
using WebApi.Repository.Repo;
using WebApi.Repository.Repositories;
using WebApi.Services.Implementations;
using WebApi.Services.Interfaces;
namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
             });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DexefdbSampleContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IGenericRepository<HrIndex>, IndexRepository>();
            builder.Services.AddScoped<IGenericRepository<HrAsset>, AssetRepository>();
            builder.Services.AddScoped<IGenericRepository<Employee>, EmployeeRepository>();
            builder.Services.AddScoped<IGenericRepository<CompanyBranch>, BranchRepository>();
            builder.Services.AddScoped<IHrIndexService, HrIndexService>();
            builder.Services.AddScoped<IHrAssetService, HrAssetService>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(e => e.Value.Errors.Select(err => new ApiError
                        {
                            StatusCode = StatusCodes.Status400BadRequest,
                            Message = err.ErrorMessage,
                            Details = string.IsNullOrEmpty(e.Key) || e.Key == "$"
                                      ? "JSON Parsing Error"
                                      : $"Field: {e.Key}",
                            Date = DateTime.UtcNow
                        }))
                        .ToList();

                    var response = new ApiResponse<object>
                    {
                        IsSuccess = false,
                        Message = "Validation failed",
                        Errors = errors,
                        Data = null
                    };

                    return new BadRequestObjectResult(response);
                };
            });



            var app = builder.Build();
            // Configure the HTTP request pipeline.
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = string.Empty; 
                });
            }
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            ;
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseMiddleware<ExceptionMiddleware>();
            app.MapControllers();
            app.Run();
        }
    }
}
