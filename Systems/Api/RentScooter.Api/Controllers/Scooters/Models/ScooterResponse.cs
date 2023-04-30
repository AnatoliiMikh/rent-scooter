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
    /// Scooter title
    /// </summary>
    public string Title { get; set; } = string.Empty;
    public int BrandId { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    //public string Name { get; set; } = string.Empty;
    //public bool IsInUse { get; set; } = false;

    /// <summary>
    /// Scooter price per minute
    /// </summary>
    public decimal PricePerMinute { get; set; } = Decimal.Zero;
    public bool IsInUse { get; set; } = false;
}

public class ScooterResponseProfile : Profile
{
    public ScooterResponseProfile()
    {
        CreateMap<ScooterModel, ScooterResponse>()
            .ForMember(d => d.Description, a => a.MapFrom(s => s.Note));
    }
}
