namespace RentScooter.Web;

using FluentValidation;

public class ScooterModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsInUse { get; set; } = false;
    public decimal PricePerMinute { get; set; } = Decimal.Zero;
}

public class ScooterModelValidator : AbstractValidator<ScooterModel>
{
    public ScooterModelValidator()
    {
        RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Name is required.");

        RuleFor(x => x.IsInUse)
            .NotEmpty().WithMessage("Status is required.");

        RuleFor(x => x.PricePerMinute)
            .NotEmpty().WithMessage("Price is required.");
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<ScooterModel>.CreateWithOptions((ScooterModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}