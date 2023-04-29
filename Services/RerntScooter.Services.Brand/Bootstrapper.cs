namespace RentScooter.Services.Brands;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddBrandService(this IServiceCollection services)
    {
        services.AddSingleton<IBrandService, BrandService>();

        return services;
    }
}
