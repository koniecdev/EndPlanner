using EndPlannerApp.Shared.Cars.Commands;

namespace Application.Cars.Commands;
public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
	public CreateCarCommandValidator()
	{
		RuleFor(m => m.Name).MinimumLength(1).MaximumLength(100).NotEmpty();
		RuleFor(m => m.Seats).GreaterThan(0).LessThan(10).NotEmpty();
		RuleFor(m => m.FuelConsumption).GreaterThan(0.5).LessThan(50).NotEmpty();
		RuleFor(m => m.FuelType).GreaterThanOrEqualTo(0).LessThanOrEqualTo(2).NotEmpty();
		RuleFor(m => m.TankLiters).GreaterThan(1).LessThan(150).NotEmpty();
		RuleFor(m => m.DriversAvailable).GreaterThan(0).LessThan(10).NotEmpty();
		RuleFor(m => m.MemberId).GreaterThan(0).LessThan(int.MaxValue).NotEmpty();
	}
}
