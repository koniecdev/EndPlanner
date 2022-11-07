using Domain.Entities;
using Domain.Entities.Fuel;

namespace EndPlannerApp.Shared.Members.Commands;

public class UpdateMemberCommand : IMapFrom<Member>, IRequest<Unit>
{
	public int Id { get; set; }
	public string UserEmail { get; set; } = "";
	public void Mapping(Profile profile)
	{
		profile.CreateMap<UpdateMemberCommand, Member>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
