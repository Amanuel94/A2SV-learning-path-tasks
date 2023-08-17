using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp_CA.Api;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
//var builder = WebApplication.CreateBuilder(args);



// var builder = WebApplication.CreateBuilder(args);


// {
//     // Add services to the container.
//     builder.Services.AddControllers();

//     // Configure Dependency Injections of other projects
//     builder.Services
//         .ConfigureApplicationServices()
//         .ConfigurePersistenceServices(builder.Configuration);

//     // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//     builder.Services.AddEndpointsApiExplorer();
//     builder.Services.AddSwaggerGen();
// }

// var app = builder.Build();


// {
//     // Configure the HTTP request pipeline.
//     if (app.Environment.IsDevelopment())
//     {
//         app.UseSwagger();
//         app.UseSwaggerUI();
//     }

//     app.UseHttpsRedirection();

//     app.UseAuthorization();

//     app.MapControllers();

//     app.Run();
// }