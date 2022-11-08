using EndPlannerApp.Shared.Cars.Commands;

namespace Application.Cars.Commands;
public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
{
	public UpdateCarCommandValidator()
	{
		RuleFor(m => m.Name).MinimumLength(1).MaximumLength(100);
		RuleFor(m => m.Seats).GreaterThan(0).LessThan(10);
		RuleFor(m => m.FuelConsumption).GreaterThan(0.5).LessThan(50);
		RuleFor(m => m.FuelType).GreaterThanOrEqualTo(0).LessThanOrEqualTo(2);
		RuleFor(m => m.TankLiters).GreaterThan(1).LessThan(150);
		RuleFor(m => m.DriversAvailable).GreaterThan(0).LessThan(10);
		RuleFor(m => m.MemberId).GreaterThan(0).LessThan(int.MaxValue);
		RuleFor(m => m.Id).GreaterThan(0).LessThan(int.MaxValue).NotEmpty();
	}
}
