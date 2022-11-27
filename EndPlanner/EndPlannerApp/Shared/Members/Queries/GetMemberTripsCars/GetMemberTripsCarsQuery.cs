namespace EndPlannerApp.Shared.Members.Queries;

public class GetMemberTripsCarsQuery : IRequest<GetMemberTripsCarsVm>
{
	public string UserId { get; set; } = "";
}
