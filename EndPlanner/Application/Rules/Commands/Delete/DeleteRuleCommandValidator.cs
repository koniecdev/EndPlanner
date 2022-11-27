using EndPlannerApp.Shared.Rules.Commands;

namespace Application.Rules.Commands;
public class DeleteRuleCommandValidator : AbstractValidator<DeleteRuleCommand>
{
	public DeleteRuleCommandValidator()
	{
		RuleFor(m => m.Id).GreaterThan(0).LessThan(int.MaxValue).NotEmpty();
	}
}
