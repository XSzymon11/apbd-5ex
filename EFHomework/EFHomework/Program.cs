using EFHomework.DAL;
using EFHomework.DTOs;
using EFHomework.Services;
using Microsoft.EntityFrameworkCore;

namespace EFHomework;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        
        builder.Services
            .AddControllers()
            .AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
            });
        
        //dane do łączenia ukryte w secret.json
        string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddDbContext<SystemDbContext>(opt =>
        {
            opt.UseNpgsql(connectionString);
        });
        
        builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();

        var app = builder.Build();

        app.UseMiddleware<Middlewares.ErrorHandlingMiddleware>();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        
        app.Run();
    }
}