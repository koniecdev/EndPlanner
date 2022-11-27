using EndPlannerApp.Shared.Trips.Commands;

namespace Application.Trips.Commands;
public class UpdateTripCommandHandler : IRequestHandler<UpdateTripCommand, Unit>
{
	private readonly IEndPlannerDbContext _db;
	private readonly IMapper _mapper;
	public UpdateTripCommandHandler(IEndPlannerDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<Unit> Handle(UpdateTripCommand command, CancellationToken cancellationToken)
	{
		var fromDb = await _db.Trips.SingleOrDefaultAsync(m => m.Id == command.Id, cancellationToken);
		if(fromDb == null)
		{
			throw new NotFoundException(command.Id.ToString(), new Exception());
		}
		_mapper.Map(command, fromDb);
		await _db.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}
