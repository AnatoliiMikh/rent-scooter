namespace RentScooter.API.Controllers.Models;

using AutoMapper;
using RentScooter.Services.Scooters;
using FluentValidation;

public class UpdateScooterRequest
{
    public string Name { get; set; } = string.Empty;
    public bool IsInUse { get; set; } = false;
    public decimal PricePerMinute { get; set; } = Decimal.Zero;
}

public class UpdateScooterRequestValidator : AbstractValidator<UpdateScooterRequest>
{
    public UpdateScooterRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.IsInUse)
            .NotEmpty().WithMessage("Status is required.");

        RuleFor(x => x.PricePerMinute)
            .NotEmpty().WithMessage("Price is required.");
    }
}

public class UpdateScooterRequestProfile : Profile
{
    public UpdateScooterRequestProfile()
    {
        CreateMap<UpdateScooterRequest, UpdateScooterModel>();
    }
}
