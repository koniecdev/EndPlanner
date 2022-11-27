using Domain.Entities;

namespace EndPlannerApp.Shared.Cars.Commands;

public class CreateCarCommand : IMapFrom<Car>, IRequest<int>
{
	public string Name { get; set; } = "";
	public int Seats { get; set; }
	public double FuelConsumption { get; set; }
	public int FuelType { get; set; }
	public int TankLiters { get; set; }
	public int MemberId { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateCarCommand, Car>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
