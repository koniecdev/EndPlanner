using EndPlannerApp.Shared.Members.Commands;

namespace Application.Members.Commands;
public class DeleteMemberCommandValidator : AbstractValidator<DeleteMemberCommand>
{
	public DeleteMemberCommandValidator()
	{
		RuleFor(m => m.Id).NotEmpty().GreaterThan(0).LessThan(int.MaxValue);
	}
}
