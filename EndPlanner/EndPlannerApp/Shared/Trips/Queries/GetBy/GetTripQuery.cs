namespace EndPlannerApp.Shared.Trips.Queries;

public class GetTripQuery : IRequest<GetTripVm>
{
	public int Id { get; set; }
}
