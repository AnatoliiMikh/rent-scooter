namespace RentScooter.API.Controllers.Brands.Models;

using AutoMapper;
using RentScooter.Services.Brands;

public class BrandResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class BrandResponseProfile : Profile
{
    public BrandResponseProfile()
    {
        CreateMap<BrandModel, BrandResponse>();
    }
}
