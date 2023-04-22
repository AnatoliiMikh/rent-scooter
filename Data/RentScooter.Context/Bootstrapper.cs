﻿namespace RentScooter.Context;

using RentScooter.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    /// <summary>
    /// Register db context
    /// </summary>
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Settings.Load<DbSettings>("Database", configuration);
        services.AddSingleton(settings);

        var dbinitoptionsdelegate = DbContextOptionsFactory.Configure(
            settings.ConnectionString,
            settings.Type);

        services.AddDbContextFactory<MainDbContext>(dbinitoptionsdelegate);

        return services;
    }
}