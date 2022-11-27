using Domain.Entities;

namespace EndPlannerApp.Shared.Trips.Queries;

public class GetTripMemberDto : IMapFrom<Member>
{
	public int Id { get; set; }
	public string UserId { get; set; } = "";
	public string UserEmail { get; set; } = "";
	public ICollection<GetTripMemberCarDto> Cars { get; set; }


	public void Mapping(Profile profile)
	{
		profile.CreateMap<Member, GetTripMemberDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}