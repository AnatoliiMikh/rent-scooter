namespace RentScooter.Web;

using FluentValidation;

public class ScooterModel
{
    public int? Id { get; set; }
    public int BrandId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class ScooterModelValidator : AbstractValidator<ScooterModel>
{
    public ScooterModelValidator()
    {
        RuleFor(v => v.Title)
              .NotEmpty().WithMessage("Title is required")
              .MaximumLength(256).WithMessage("Title length must be less then 256")
              ;

        RuleFor(v => v.BrandId)
            .GreaterThan(0).WithMessage("Please, select an brand");

        RuleFor(v => v.Description)
             .MaximumLength(1024).WithMessage("Description length must be less then 1024");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<ScooterModel>.CreateWithOptions((ScooterModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}