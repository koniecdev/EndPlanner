using EndPlannerApp.Shared.Members.Commands;

namespace Application.Members.Commands;
public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, Unit>
{
	private readonly IEndPlannerDbContext _db;
	public DeleteMemberCommandHandler(IEndPlannerDbContext db)
	{
		_db = db;
	}
	public async Task<Unit> Handle(DeleteMemberCommand command, CancellationToken cancellationToken)
	{
		var fromDb = await _db.Members.SingleOrDefaultAsync(m=>m.Id == command.Id, cancellationToken);
		if(fromDb == null)
		{
			throw new NotFoundException(command.Id.ToString(), new Exception());
		}
		_db.Members.Remove(fromDb);
		await _db.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}
