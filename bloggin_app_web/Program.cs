using System.Text.Json.Serialization;
using BloggingApp.Models;
using Microsoft.EntityFrameworkCore;
using BloggingApp.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// builder.Services.AddControllers()
// .AddJsonOptions(options =>
//         {
//             options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//         });
// builder.Services.AddControllers().AddJsonOptions(options => 
// { 
//     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//     options.JsonSerializerOptions.WriteIndented = true;
// });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultDbConnection")));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
