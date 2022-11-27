using EndPlannerApp.Shared.Countries.Commands;

namespace Application.Countries.Commands;
public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
{
	public UpdateCountryCommandValidator()
	{
		RuleFor(m => m.Id).GreaterThan(1).LessThan(int.MaxValue).NotEmpty();
		RuleFor(m => m.Name).MinimumLength(3).MaximumLength(100);
		RuleFor(m => m.CountryCode).Length(2);
		RuleFor(m => m.CountryCode3).Length(3);
		RuleFor(m => m.CurrencyCode).Length(3);
	}
}
