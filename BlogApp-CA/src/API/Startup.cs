// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.

// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

// app.Run();
using Microsoft.OpenApi.Models;
namespace BlogApp_CA.Api;
public class Startup{

    public IConfiguration Configuration{get;}
    public Startup(IConfiguration configuration){
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services){
        services.ConfigureApplicationServices();
        services.ConfigurePersistenceServices(Configuration);

        services.AddControllers();
        services.AddSwaggerGen(c=>{
            c.SwaggerDoc("v1", new OpenApiInfo{Title="BlogApp_CA.Api", Version = "v1"});
        });

        services.AddCors(o=>{
            o.AddPolicy("CorsPolicy",
            builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );
        });

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
        if(env.IsDevelopment()){
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlogApp_CA.Api v1"));
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseCors("CorsPolicy");
        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
        });
    }



}
