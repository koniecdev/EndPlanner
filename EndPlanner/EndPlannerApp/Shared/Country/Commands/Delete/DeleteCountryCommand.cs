namespace EndPlannerApp.Shared.Countries.Commands;

public class DeleteCountryCommand : IRequest<Unit>
{
	public int Id { get; set; }
}
