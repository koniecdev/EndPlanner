using EndPlannerApp.Shared.Cars.Commands;

namespace Application.Cars.Commands;
public class DeleteCarCommandValidator : AbstractValidator<DeleteCarCommand>
{
	public DeleteCarCommandValidator()
	{
		RuleFor(m => m.Id).GreaterThan(0).LessThan(int.MaxValue).NotEmpty();
	}
}
