namespace RentScooter.Services.Rents;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddRentService(this IServiceCollection services)
    {
        services.AddSingleton<IRentService, RentService>();

        return services;
    }
}
