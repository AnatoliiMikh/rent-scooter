namespace RentScooter.Services.Scooters;

using AutoMapper;
using RentScooter.Context.Entities;
using FluentValidation;

public class UpdateScooterModel
{
    public string Name { get; set; } = string.Empty;
    public bool IsInUse { get; set; } = false;
    public decimal PricePerMinute { get; set; } = Decimal.Zero;
}

public class UpdateScooterModelValidator : AbstractValidator<UpdateScooterModel>
{
    public UpdateScooterModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.IsInUse)
            .NotEmpty().WithMessage("Status is required.");

        RuleFor(x => x.PricePerMinute)
            .NotEmpty().WithMessage("Price is required.");
    }
}

public class UpdateBookModelProfile : Profile
{
    public UpdateBookModelProfile()
    {
        CreateMap<UpdateScooterModel, Scooter>();
    }
}