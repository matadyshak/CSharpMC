using MyApp.Core.Interfaces;
using MyApp.Infrastructure.Repositories;

namespace MyApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Register services
            // With AddScoped CustomerRepository gets a new instance and a new List _customers after each POST command
            // With AddSingleton there is one instance of CustomerRepository and _customers over the life of the app
            builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
