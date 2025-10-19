using Domain.Config;
using CrudProductManagement.Configurations;
using Microsoft.AspNetCore.Http.Features;

namespace CrudProductManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDependenciesInjectionConfig();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCorsDocumentation();
            builder.Services.AddAutoMapperConfig();
            builder.Services.Configure<FormOptions>(opt =>
            {
                opt.ValueLengthLimit = int.MaxValue;
                opt.MultipartBodyLengthLimit = int.MaxValue;
                opt.MemoryBufferThreshold = int.MaxValue;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCorsDocumentation();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
