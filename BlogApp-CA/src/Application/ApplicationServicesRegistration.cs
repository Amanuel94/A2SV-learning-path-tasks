using BlogApp_CA.Application.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

public static class ApplicationServicesRegistration{

    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services){
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServicesRegistration).Assembly));

        return services;
    }


}