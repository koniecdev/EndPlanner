using Domain.Entities;

namespace EndPlannerApp.Shared.Members.Queries;

public class GetMemberTripsCarsVm : IMapFrom<Member>
{
	public ICollection<Car> Cars { get; set; }
	public ICollection<Trip> Trips { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Member, GetMemberTripsCarsVm>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
