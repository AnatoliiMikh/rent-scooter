namespace RentScooter.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentScooter.Context;

public static class DbSeeder
{
    private static IServiceScope ServiceScope(IServiceProvider serviceProvider) => serviceProvider.GetService<IServiceScopeFactory>()!.CreateScope();
    private static MainDbContext DbContext(IServiceProvider serviceProvider) => ServiceScope(serviceProvider).ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>().CreateDbContext();

    //private static readonly string masterUserName = "Admin";
    //private static readonly string masterUserEmail = "admin@dsrnetscool.com";
    //private static readonly string masterUserPassword = "Pass123#";

    //private static void ConfigureAdministrator(IServiceScope scope)
    //{
    //    //    var defaults = scope.ServiceProvider.GetService<IDefaultsSettings>();

    //    //    if (defaults != null)
    //    //    {
    //    //        var userService = scope.ServiceProvider.GetService<IUserService>();
    //    //        if (addAdmin && (!userService?.Any() ?? false))
    //    //        {
    //    //            var user = userService.Create(new CreateUserModel
    //    //            {
    //    //                Type = UserType.ForPortal,
    //    //                Status = UserStatus.Active,
    //    //                Name = defaults.AdministratorName,
    //    //                Password = defaults.AdministratorPassword,
    //    //                Email = defaults.AdministratorEmail,
    //    //                IsEmailConfirmed = !defaults.AdministratorEmail.IsNullOrEmpty(),
    //    //                Phone = null,
    //    //                IsPhoneConfirmed = false,
    //    //                IsChangePasswordNeeded = true
    //    //            })
    //    //                .GetAwaiter()
    //    //                .GetResult();

    //    //            userService.SetUserRoles(user.Id, Infrastructure.User.UserRole.Administrator).GetAwaiter().GetResult();
    //    //        }
    //    //    }
    //}

    public static void Execute(IServiceProvider serviceProvider, bool addDemoData, bool addAdmin = true)
    {
        using var scope = ServiceScope(serviceProvider);
        ArgumentNullException.ThrowIfNull(scope);

        //if (addAdmin)
        //{
        //    ConfigureAdministrator(scope);
        //}

        if (addDemoData)
        {
            Task.Run(async () =>
            {
                await ConfigureDemoData(serviceProvider);
            });
        }
    }

    private static async Task ConfigureDemoData(IServiceProvider serviceProvider)
    {
        await AddScooters(serviceProvider);
    }

    private static async Task AddScooters(IServiceProvider serviceProvider)
    {
        await using var context = DbContext(serviceProvider);

        if (context.Scooters.Any() || context.Brands.Any() || context.Rents.Any())
            return;

        var b1 = new Entities.Brand()
        {
            Name = "Segway",
            Detail = new Entities.BrandDetail()
            {
                Country = "China",
                StockTicket = "",
            }
        };
        context.Brands.Add(b1);

        var b2 = new Entities.Brand()
        {
            Name = "Razor",
            Detail = new Entities.BrandDetail()
            {
                Country = "USA",
                StockTicket = "",
            }
        };
        context.Brands.Add(b2);

        var r1 = new Entities.Rent()
        {
            Title = "Classic"
        };
        context.Rents.Add(r1);

        context.Scooters.Add(new Entities.Scooter()
        {
            Title = "Ninebot Kickscooter Max",
            Description = "The best electric scooter for those who want to go far",
            Brand = b1,
            Rents = new List<Entities.Rent>() { r1 },
        });

        context.Scooters.Add(new Entities.Scooter()
        {
            Title = "E100",
            Description = "Best electric scooter for kids",
            Brand = b2,
            Rents = new List<Entities.Rent>() { r1 },
        });

        context.SaveChanges();
    }
}