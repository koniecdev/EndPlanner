using EndPlannerApp.Shared.Rules.Commands;

namespace Application.Rules.Commands;
public class UpdateRuleCommandValidator : AbstractValidator<UpdateRuleCommand>
{
	public UpdateRuleCommandValidator()
	{
		RuleFor(m => m.Description).MinimumLength(3).MaximumLength(100);
		RuleFor(m => m.CountryId).GreaterThan(0).LessThan(int.MaxValue);
	}
}
