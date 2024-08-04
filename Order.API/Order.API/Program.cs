using Order.API.DatabaseContexts;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Order.API.Repositories;

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

        builder.Services.AddDbContext<OrderContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("OrderContext"));
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