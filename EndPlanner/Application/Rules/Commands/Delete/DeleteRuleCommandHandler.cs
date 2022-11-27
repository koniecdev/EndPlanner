using EndPlannerApp.Shared.Rules.Commands;

namespace Application.Rules.Commands;
public class DeleteRuleCommandHandler : IRequestHandler<DeleteRuleCommand, Unit>
{
	private readonly IEndPlannerDbContext _db;
	public DeleteRuleCommandHandler(IEndPlannerDbContext db)
	{
		_db = db;
	}
	public async Task<Unit> Handle(DeleteRuleCommand command, CancellationToken cancellationToken)
	{
		var fromDb = await _db.Rules.SingleOrDefaultAsync(m=>m.Id == command.Id, cancellationToken);
		if(fromDb == null)
		{
			throw new NotFoundException(command.Id.ToString(), new Exception());
		}
		_db.Rules.Remove(fromDb);
		await _db.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}
