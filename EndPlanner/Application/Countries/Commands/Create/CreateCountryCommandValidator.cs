using EndPlannerApp.Shared.Countries.Commands;

namespace Application.Countries.Commands;
public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
{
	public CreateCountryCommandValidator()
	{
		RuleFor(m => m.Name).MinimumLength(3).MaximumLength(100).NotEmpty();
		RuleFor(m => m.CountryCode).Length(2).NotEmpty();
		RuleFor(m => m.CountryCode3).Length(3).NotEmpty();
		RuleFor(m => m.CurrencyCode).Length(3).NotEmpty();
	}
}
