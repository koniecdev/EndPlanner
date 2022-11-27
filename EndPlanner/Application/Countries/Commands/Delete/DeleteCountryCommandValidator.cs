using EndPlannerApp.Shared.Countries.Commands;

namespace Application.Countries.Commands;
public class DeleteCountryCommandValidator : AbstractValidator<DeleteCountryCommand>
{
	public DeleteCountryCommandValidator()
	{
		RuleFor(m => m.Id).GreaterThan(0).LessThan(int.MaxValue).NotEmpty();
	}
}
