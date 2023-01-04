
using AirlineWeb.Data;
using AirlineWeb.MessageBus;
using Microsoft.EntityFrameworkCore;

namespace AirlineWeb
{
    public class Program
    {
        // if you have any certificate issues run the command:
        // dotnet dev-certs https --trust
        // if it does not solves, pass a TrustServerCertificate=True in the connection string

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add DbContext to the container.
            builder.Services.AddDbContext<AirlineDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("AirlineConnection")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new() { Title = "AirlineWeb", Version = "v1" }); });

            // adds automapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Adds MessageBusClient to the container.
            builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}