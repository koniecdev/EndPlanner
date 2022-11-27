using EndPlannerApp.Shared.Rules.Commands;

namespace Application.Rules.Commands;
public class CreateRuleCommandValidator : AbstractValidator<CreateRuleCommand>
{
	public CreateRuleCommandValidator()
	{
		RuleFor(m => m.Description).MinimumLength(3).MaximumLength(100).NotEmpty();
		RuleFor(m => m.CountryId).GreaterThan(0).LessThan(int.MaxValue).NotEmpty();
		RuleFor(m => m.TripId).GreaterThan(0).LessThan(int.MaxValue).NotEmpty();
	}
}
