using Domain.Entities;
using Domain.ValueObjects;

namespace EndPlannerApp.Shared.Trips.Queries;

public class GetTripRouteDto : IMapFrom<Route>
{
	public int Order { get; set; }
	public int? BorderDistance { get; set; }
	public double? SleepoverCost { get; set; }
	public DateTime? LeavingDate { get; set; }
	public Address? Address { get; set; }
	public int CountryId { get; set; }
	public GetTripRouteCountryDto Country { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<Route, GetTripRouteDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}