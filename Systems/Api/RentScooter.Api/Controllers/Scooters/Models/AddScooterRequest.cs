namespace RentScooter.API.Controllers.Models;

using AutoMapper;
using RentScooter.Services.Scooters;
using FluentValidation;

public class AddScooterRequest
{
    //public string Name { get; set; } = string.Empty;
    //public bool IsInUse { get; set; } = false;
    //public decimal PricePerMinute { get; set; } = Decimal.Zero;

    public int BrandId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class AddScooterResponseValidator : AbstractValidator<AddScooterRequest>
{
    public AddScooterResponseValidator()
    {
        //RuleFor(x => x.Name)
        //    .NotEmpty().WithMessage("Name is required.");

        //RuleFor(x => x.IsInUse)
        //    .NotEmpty().WithMessage("Status is required.");

        //RuleFor(x => x.PricePerMinute)
        //    .NotEmpty().WithMessage("Price is required.");

        RuleFor(x => x.BrandId)
            .NotEmpty().WithMessage("Brand is required.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(50).WithMessage("Title is long.");

        RuleFor(x => x.Description)
            .MaximumLength(2000).WithMessage("Description is long.");
    }
}

public class AddScooterRequestProfile : Profile
{
    public AddScooterRequestProfile()
    {
        CreateMap<AddScooterRequest, AddScooterModel>()
            .ForMember(d => d.Note, a => a.MapFrom(s => s.Description));

    }
}

