using Domain.Entities;
using Domain.ValueObjects;

namespace EndPlannerApp.Shared.Trips.Commands;

public class UpdateTripCommand : IMapFrom<Trip>, IRequest<Unit>
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public DateTime? StartingDate { get; set; }
	public Address? Address { get; set; }
	public int? CarId { get; set; }
	public int? DriversAvailable { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<UpdateTripCommand, Trip>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

	}
}
