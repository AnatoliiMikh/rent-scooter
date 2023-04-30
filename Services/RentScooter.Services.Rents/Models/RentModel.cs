namespace RentScooter.Services.Rents;

using AutoMapper;
using RentScooter.Context.Entities;

public class RentModel
{
    public int Id { get; set; } //у всех есть 
    public string Title { get; set; } = string.Empty;
    public decimal TotalRevenue { get; set; } = decimal.Zero;
    public DateTime RentTime { get; set; } = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified);
    public DateTime ReturnTime { get; set; } = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified);   
}

public class RentModelProfile : Profile
{
    public RentModelProfile()
    {
        CreateMap<Rent, RentModel>();
    }
}