using Domain.Entities;

namespace EndPlannerApp.Shared.Rules.Commands;

public class UpdateRuleCommand : IMapFrom<Rule>, IRequest<Unit>
{
	public int Id { get; set; }
	public string? Description { get; set; }
	public int? CountryId { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<UpdateRuleCommand, Rule>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
