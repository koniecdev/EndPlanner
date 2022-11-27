using Domain.Entities;

namespace EndPlannerApp.Shared.Rules.Commands;

public class CreateRuleCommand : IMapFrom<Rule>, IRequest<int>
{
	public string Description { get; set; } = "";
	public int CountryId { get; set; }
	public int TripId { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateRuleCommand, Rule>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
