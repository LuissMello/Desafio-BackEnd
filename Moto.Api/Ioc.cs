using MassTransit;
using Microsoft.EntityFrameworkCore;
using Moto.Application.Abstractions;
using Moto.Application.Events;
using Moto.Application.Services;
using Moto.Domain.Abstractions;
using Moto.Infrastructure.Base;
using Moto.Infrastructure.Context;
using Moto.Infrastructure.Repositories;

namespace Moto.Api;

public static class Ioc
{
    public static IServiceCollection ResolveDepensencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        AddServices(services);
        AddDatabase(services, configuration);
        AddRepositories(services);
        AddeQueues(services, configuration);
        return services;
    }


    static void AddeQueues(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();

            busConfigurator.AddConsumer<BikeCreatedConsumer>();

            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(configuration["MessageBroker:Host"]!));

                configurator.ConfigureEndpoints(context);
            });

        });
    }

    static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IUserServices, UserServices>();
        services.AddScoped<IBikeServices, BikeServices>();
        services.AddScoped<IPlanServices, PlanServices>();
        services.AddScoped<IRentServices, RentServices>();
    }

    static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBikeRepository, BikeRepository>();
        services.AddScoped<IPlanRepository, PlanRepository>();
        services.AddScoped<IRentRepository, RentRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    static void AddDatabase(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MotoDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Database")), ServiceLifetime.Scoped);
    }
}
