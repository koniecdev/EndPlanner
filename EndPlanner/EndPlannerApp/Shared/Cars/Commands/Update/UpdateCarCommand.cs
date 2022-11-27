using Domain.Entities;

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
		profile.CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
		profile.CreateMap<DateTime?, DateTime>().ConvertUsing((src, dest) => src ?? dest);
		profile.CreateMap<UpdateCarCommand, Car>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

	}
}
