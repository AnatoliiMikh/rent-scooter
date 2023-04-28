namespace RentScooter.API.Controllers.Models;

using AutoMapper;
using RentScooter.Services.Scooters;

public class ScooterResponse
{
    /// <summary>
    /// Scooter Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Scooter name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    public bool IsInUse { get; set; } = false;
    public decimal PricePerMinute { get; set; } = Decimal.Zero;
}

public class ScooterResponseProfile : Profile
{
    public ScooterResponseProfile()
    {
        CreateMap<ScooterModel, ScooterResponse>();
    }
}
