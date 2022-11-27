using EndPlannerApp.Shared.Trips.Commands;

namespace Application.Trips.Commands;
public class DeleteTripCommandValidator : AbstractValidator<DeleteTripCommand>
{
	public DeleteTripCommandValidator()
	{
		RuleFor(m => m.Id).GreaterThan(0).LessThan(int.MaxValue).NotEmpty();
	}
}
