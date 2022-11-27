using Domain.Entities;

namespace EndPlannerApp.Shared.Trips.Queries;

public class GetTripCarDto : IMapFrom<Car>
{
	public int Id { get; set; }
	public string Name { get; set; } = "";
	public int Seats { get; set; }
	public double FuelConsumption { get; set; }
	public int FuelType { get; set; }
	public int TankLiters { get; set; }
	public int DriversAvailable { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<Car, GetTripCarDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}