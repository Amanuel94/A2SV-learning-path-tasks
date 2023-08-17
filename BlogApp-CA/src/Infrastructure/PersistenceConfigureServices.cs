using BlogApp_CA.Application.Repositories;
using BlogApp_CA.Domain.Events;
using BlogApp_CA.Infrastructure.Persistence;
using BlogApp_CA.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
{
    services.AddDbContext<ApplicationDbContext>(
        options => options.UseNpgsql(configuration.GetConnectionString("DefaultConn"))
    );
    services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    services.AddScoped<IPostRepository, PostRepository>();
    services.AddScoped<ICommentRepository, CommentRepository>();

    
    return services;
}
}
