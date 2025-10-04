using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using WebApi.Controllers;
using WebApi.Data.Context;
using WebApi.Data.Models;
using WebApi.Helper;
using WebApi.Middlwares;
using WebApi.Models;
using WebApi.Repository.IRepo;
using WebApi.Repository.Repo;
using WebApi.Repository.Repositories;

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
            builder.Services.AddAutoMapper(typeof(MappingProfile));
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
