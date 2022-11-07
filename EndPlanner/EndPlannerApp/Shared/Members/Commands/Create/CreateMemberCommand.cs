using Domain.Entities;
using Domain.Entities.Fuel;

namespace EndPlannerApp.Shared.Members.Commands;

public class CreateMemberCommand : IMapFrom<Member>, IRequest<int>
{
	public string UserEmail { get; set; } = "";
	public string UserId { get; set; } = "";
	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateMemberCommand, Member>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
