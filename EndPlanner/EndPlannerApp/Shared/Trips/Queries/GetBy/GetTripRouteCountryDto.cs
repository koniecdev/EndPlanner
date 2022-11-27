using Domain.Entities;

namespace EndPlannerApp.Shared.Trips.Queries;

public class GetTripRouteCountryDto : IMapFrom<Country>
{
	public int Id { get; set; }
	public string Name { get; set; } = "";

	public void Mapping(Profile profile)
	{
		profile.CreateMap<Country, GetTripRouteCountryDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}