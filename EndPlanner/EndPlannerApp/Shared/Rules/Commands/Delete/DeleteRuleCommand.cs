namespace EndPlannerApp.Shared.Rules.Commands;

public class DeleteRuleCommand : IRequest<Unit>
{
	public int Id { get; set; }
}
