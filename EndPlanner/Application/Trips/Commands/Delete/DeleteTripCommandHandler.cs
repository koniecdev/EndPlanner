using EndPlannerApp.Shared.Trips.Commands;

namespace Application.Trips.Commands;
public class DeleteTripCommandHandler : IRequestHandler<DeleteTripCommand, Unit>
{
	private readonly IEndPlannerDbContext _db;
	public DeleteTripCommandHandler(IEndPlannerDbContext db)
	{
		_db = db;
	}
	public async Task<Unit> Handle(DeleteTripCommand command, CancellationToken cancellationToken)
	{
		var fromDb = await _db.Trips.SingleOrDefaultAsync(m=>m.Id == command.Id, cancellationToken);
		if(fromDb == null)
		{
			throw new NotFoundException(command.Id.ToString(), new Exception());
		}
		_db.Trips.Remove(fromDb);
		await _db.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}
