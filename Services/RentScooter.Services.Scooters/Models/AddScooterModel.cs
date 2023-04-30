namespace RentScooter.Services.Scooters;

using AutoMapper;
using RentScooter.Context.Entities;
using FluentValidation;

public class AddScooterModel
{
    //public string Name { get; set; } = string.Empty;
    //public bool IsInUse { get; set; } = false;
    public decimal PricePerMinute { get; set; } = Decimal.Zero;
    public bool IsInUse { get; set; } = false;

    public int BrandId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;

}

public class AddScooterModelValidator : AbstractValidator<AddScooterModel>
{
    public AddScooterModelValidator()
    {
        //RuleFor(x => x.Name)
        //    .NotEmpty().WithMessage("Name is required.");

        //RuleFor(x => x.IsInUse)
            //.NotEmpty().WithMessage("Status is required.");

        RuleFor(x => x.PricePerMinute)
            .NotEmpty().WithMessage("Price is required.");

        RuleFor(x => x.BrandId)
            .NotEmpty().WithMessage("Brand is required.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(50).WithMessage("Title is long.");

        RuleFor(x => x.Note)
            .MaximumLength(2000).WithMessage("Description is long.");

    }
}

public class AddBookModelProfile : Profile
{
    public AddBookModelProfile()
    {
        CreateMap<AddScooterModel, Scooter>()
            .ForMember(d => d.Description, a => a.MapFrom(s => s.Note));
    }
}