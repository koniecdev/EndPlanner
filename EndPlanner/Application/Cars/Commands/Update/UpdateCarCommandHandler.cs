using EndPlannerApp.Shared.Cars.Commands;
using EndPlannerApp.Shared.Members.Commands;

namespace Application.Cars.Commands;
public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Unit>
{
	private readonly IEndPlannerDbContext _db;
	private readonly IMapper _mapper;
	public UpdateCarCommandHandler(IEndPlannerDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<Unit> Handle(UpdateCarCommand command, CancellationToken cancellationToken)
	{
		var fromDb = await _db.Cars.SingleOrDefaultAsync(m => m.Id == command.Id, cancellationToken);
		if(fromDb == null)
		{
			throw new NotFoundException(command.Id.ToString(), new Exception());
		}
		_mapper.Map(command, fromDb);
		await _db.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}
