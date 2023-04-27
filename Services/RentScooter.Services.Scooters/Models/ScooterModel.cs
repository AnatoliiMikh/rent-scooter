namespace RentScooter.Services.Scooters;

using AutoMapper;
using RentScooter.Context.Entities;

public class ScooterModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class ScooterModelProfile : Profile
{
    public ScooterModelProfile()
    {
        CreateMap<Scooter, ScooterModel>();
    }
}
