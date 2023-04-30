namespace RentScooter.Api;

using RentScooter.Api.Settings;
using RentScooter.Services.Actions;
using RentScooter.Services.Brands;
using RentScooter.Services.Scooters;
using RentScooter.Services.Cache;
using RentScooter.Services.RabbitMq;
using RentScooter.Services.Settings;
using RentScooter.Services.UserAccount;
using Microsoft.Extensions.DependencyInjection;
using RentScooter.Services.Rents;

public static class Bootstrapper
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services
            .AddMainSettings()
            .AddSwaggerSettings()
            .AddIdentitySettings()
            .AddApiSpecialSettings()
            .AddScooterService()
            .AddUserAccountService()
            .AddCache()
            .AddRabbitMq()
            .AddActions()
            .AddBrandService()
            .AddRentService()
            ;

        return services;
    }
}
