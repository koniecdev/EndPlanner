using Domain.Entities;

namespace EndPlannerApp.Shared.Trips.Queries;

public class GetTripRuleDto : IMapFrom<Rule>
{
	public int Id { get; set; }
	public string Description { get; set; } = "";
	public int CountryId { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<Rule, GetTripRuleDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}