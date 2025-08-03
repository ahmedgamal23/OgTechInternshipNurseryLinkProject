
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NurseryLinkProject.Domain.Data;
using System.Reflection;


namespace NurseryLinkProject.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            
            // add swagger configuration
            builder.Services.AddSwaggerGen(builder =>
            {
                builder.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "NurseryLink API",
                    Version = "v1",
                    Description = "API for NurseryLink Project"
                });
            });

            // Add connection to the database
            builder.Services.AddDbContext<AppDbContext>(ops =>
            {
                ops.UseSqlServer(builder.Configuration.GetConnectionString("NurseryLinkConn"));
            });

            // register auto mapper
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "NurseryLink API V1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
