using Domain.Entities;
using Domain.ValueObjects;

namespace EndPlannerApp.Shared.Trips.Queries;

public class GetTripVm : IMapFrom<Trip>
{
	public int Id { get; set; }
	public string Name { get; set; } = "";
	public DateTime? StartingDate { get; set; }
	public Address? Address { get; set; }
	public int? CarId { get; set; }
	public GetTripCarDto Car { get; set; }
	public ICollection<GetTripRouteDto> Routes { get; set; }
	public ICollection<GetTripMemberDto> Members { get; set; }
	public ICollection<GetTripRuleDto> Rules { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Trip, GetTripVm>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}