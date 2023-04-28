namespace RentScooter.Worker;

using RentScooter.Services.EmailSender;
using RentScooter.Services.RabbitMq;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services
            .AddRabbitMq()            
            .AddEmailSender()
            ;

        services.AddSingleton<ITaskExecutor, TaskExecutor>();

        return services;
    }
}
 



