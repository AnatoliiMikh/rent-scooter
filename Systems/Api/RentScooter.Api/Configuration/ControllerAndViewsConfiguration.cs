namespace RentScooter.Api.Configuration;

using RentScooter.Common;

public static class ControllerAndViewsConfiguration
{
    public static IServiceCollection AddAppControllerAndViews(this IServiceCollection services)
    {
        services
            .AddRazorPages();

        services
            .AddControllers()
            .AddNewtonsoftJson(options => options.SerializerSettings.SetDefaultSettings())
            .AddValidator() //Закомментировал на 1:16:05 Workshop 1, тк там этого нет, тк валидация будет позже //Раскомменатирвали на 1:44:0 ws2
            ;

        return services;
    }

    public static IEndpointRouteBuilder UseAppControllerAndViews(this IEndpointRouteBuilder app)
    {
        app.MapRazorPages();
        app.MapControllers();

        return app;
    }
}