using Order.API.DatabaseContexts;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Order.API.Repositories;
using System.Text;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<DbContext, OrderContext>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();

        builder.Configuration.AddJsonFile("appsettings.json", false);
        builder.Configuration.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", false);
        builder.Configuration.AddEnvironmentVariables();



        var dbConnectionStringBuilder = new StringBuilder(builder.Configuration.GetConnectionString("OrderContext"));

        dbConnectionStringBuilder.Replace("API_POSTGRES_USER", Environment.GetEnvironmentVariable("API_POSTGRES_USER"));
        dbConnectionStringBuilder.Replace("API_POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("API_POSTGRES_PASSWORD"));
        dbConnectionStringBuilder.Replace("API_POSTGRES_DB", Environment.GetEnvironmentVariable("API_POSTGRES_DB"));
        dbConnectionStringBuilder.Replace("API_POSTGRES_SERVER", Environment.GetEnvironmentVariable("API_POSTGRES_SERVER"));

        builder.Services.AddDbContext<OrderContext>(options =>
        {
            options.UseNpgsql(dbConnectionStringBuilder.ToString());
        });

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}