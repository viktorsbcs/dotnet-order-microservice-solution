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

        var connectionStringBuilder = new StringBuilder(builder.Configuration.GetConnectionString("OrderContext"));

        connectionStringBuilder.Replace("{{postgres_user}}", builder.Configuration["postgres_user"]);
        connectionStringBuilder.Replace("{{postgres_pw}}", builder.Configuration["postgres_pw"]);

        builder.Services.AddDbContext<OrderContext>(options =>
        {
            options.UseNpgsql(connectionStringBuilder.ToString());
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}