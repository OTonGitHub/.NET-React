using Application.Activities;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("DefaultConnection"));
        }); // transitive dependency to persistece via application.
            // hence, EFCore and Persistence are available here, even though this project only depends on Application project.
        services.AddCors(opt =>
        {
            opt.AddPolicy("CORSPolicy", policy =>
            {
                policy.AllowAnyHeader().AllowAnyMethod()
                .WithOrigins("http://127.0.0.1:3000"); // use configuration?
            });
        });
        // registtering one handler is fine, because from assembly, all handlers in assembly will be picked up.
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(typeof(Listie.Handler).Assembly)
        );

        return services;
    }
}