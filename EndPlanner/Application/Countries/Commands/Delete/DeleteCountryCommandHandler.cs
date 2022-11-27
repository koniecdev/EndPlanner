using EndPlannerApp.Shared.Countries.Commands;

namespace Application.Countries.Commands;
public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Unit>
{
	private readonly IEndPlannerDbContext _db;
	public DeleteCountryCommandHandler(IEndPlannerDbContext db)
	{
		_db = db;
	}
	public async Task<Unit> Handle(DeleteCountryCommand command, CancellationToken cancellationToken)
	{
		var fromDb = await _db.Countries.SingleOrDefaultAsync(m=>m.Id == command.Id, cancellationToken);
		if(fromDb == null)
		{
			throw new NotFoundException(command.Id.ToString(), new Exception());
		}
		_db.Countries.Remove(fromDb);
		await _db.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}
