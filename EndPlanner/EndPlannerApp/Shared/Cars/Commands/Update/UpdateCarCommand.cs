using Domain.Entities;
using Domain.Entities.Fuel;

namespace EndPlannerApp.Shared.Cars.Commands;

public class UpdateCarCommand : IMapFrom<Car>, IRequest<Unit>
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public int? Seats { get; set; }
	public double? FuelConsumption { get; set; }
	public int? FuelType { get; set; }
	public int? TankLiters { get; set; }
	public int? DriversAvailable { get; set; }
	public int? MemberId { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<UpdateCarCommand, Car>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
