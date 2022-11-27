using EndPlannerApp.Shared.Cars.Commands;

namespace Application.Cars.Commands;
public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, Unit>
{
	private readonly IEndPlannerDbContext _db;
	public DeleteCarCommandHandler(IEndPlannerDbContext db)
	{
		_db = db;
	}
	public async Task<Unit> Handle(DeleteCarCommand command, CancellationToken cancellationToken)
	{
		var fromDb = await _db.Cars.SingleOrDefaultAsync(m=>m.Id == command.Id, cancellationToken);
		if(fromDb == null)
		{
			throw new NotFoundException(command.Id.ToString(), new Exception());
		}
		_db.Cars.Remove(fromDb);
		await _db.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}
