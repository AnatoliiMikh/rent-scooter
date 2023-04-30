namespace RentScooter.Services.Brands;

using AutoMapper;
using RentScooter.Context.Entities;

public class BrandModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class BrandModelProfile : Profile
{
    public BrandModelProfile()
    {
        CreateMap<Brand, BrandModel>();
    }
}
