namespace RentScooter.Identity.Configuration;

using RentScooter.Common.Security;
using Duende.IdentityServer.Models;

public static class AppApiScopes
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope(AppScopes.ScootersRead, "Access to scooters API - Read data"),
            new ApiScope(AppScopes.ScootersWrite, "Access to scooters API - Write data")
        };
}