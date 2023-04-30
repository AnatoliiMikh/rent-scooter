namespace RentScooter.Api.Controllers.Rents.Models;

using AutoMapper;
using RentScooter.Services.Rents;
public class RentResponse
{
    public int Id { get; set; } //у всех есть 
    public string Title { get; set; } = string.Empty;
    public decimal TotalRevenue { get; set; } = decimal.Zero;
    public DateTime RentTime { get; set; } = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified);
    public DateTime ReturnTime { get; set; } = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified);
}

public class RentResponseProfile : Profile
{
    public RentResponseProfile()
    {
        CreateMap<RentModel, RentResponse>();
    }
}