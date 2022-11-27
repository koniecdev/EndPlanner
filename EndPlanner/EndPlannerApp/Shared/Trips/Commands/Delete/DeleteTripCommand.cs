namespace EndPlannerApp.Shared.Trips.Commands;

public class DeleteTripCommand : IRequest<Unit>
{
	public int Id { get; set; }
}
