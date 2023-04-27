namespace RentScooter.Services.Scooters;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddScooterService(this IServiceCollection services)
    {
        services.AddSingleton<IScooterService, ScooterService>();

        return services;
    }
}
