namespace RentScooter.Services.Scooters;

using AutoMapper;
using RentScooter.Context.Entities;

public class ScooterModel
{
    //public int Id { get; set; }
    //public string Name { get; set; } = string.Empty;
    //public bool IsInUse { get; set; } = false;
    public decimal PricePerMinute { get; set; } = Decimal.Zero;
    public bool IsInUse { get; set; } = false;

    public int Id { get; set; }
    public int BrandId { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
}

public class ScooterModelProfile : Profile
{
    public ScooterModelProfile()
    {
        CreateMap<Scooter, ScooterModel>()
            .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name));
    }
}
