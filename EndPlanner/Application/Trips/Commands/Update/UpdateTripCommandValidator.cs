using EndPlannerApp.Shared.Trips.Commands;

namespace Application.Trips.Commands;
public class UpdateTripCommandValidator : AbstractValidator<UpdateTripCommand>
{
	private readonly IDateTime _dateTime;
	public UpdateTripCommandValidator(IDateTime dateTime)
	{
		_dateTime = dateTime;
		RuleFor(m => m.Name).MinimumLength(3).MaximumLength(100);
		RuleFor(m => m.StartingDate).GreaterThan(_dateTime.Yesterday);
		RuleFor(m => m.CarId).GreaterThan(0).LessThan(int.MaxValue);
		RuleFor(m => m.DriversAvailable).GreaterThan(0).LessThan(9);
	}
}
