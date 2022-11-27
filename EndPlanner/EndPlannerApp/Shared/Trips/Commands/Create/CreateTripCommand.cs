using Domain.Entities;
using Domain.ValueObjects;

namespace EndPlannerApp.Shared.Trips.Commands;

public class CreateTripCommand : IMapFrom<Trip>, IRequest<int>
{
	public string Name { get; set; } = "";
	public int DriversAvailable { get; set; }
	public DateTime? StartingDate { get; set; }
	public Address? Address { get; set; }
	public int? CarId { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateTripCommand, Trip>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
