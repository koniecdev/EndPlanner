using EndPlannerApp.Shared.Countries.Commands;

namespace Application.Countries.Commands;
public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Unit>
{
	private readonly IEndPlannerDbContext _db;
	private readonly IMapper _mapper;
	public UpdateCountryCommandHandler(IEndPlannerDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<Unit> Handle(UpdateCountryCommand command, CancellationToken cancellationToken)
	{
		var fromDb = await _db.Countries.SingleOrDefaultAsync(m => m.Id == command.Id, cancellationToken);
		if(fromDb == null)
		{
			throw new NotFoundException(nameof(UpdateCountryCommand), new Exception());
		}
		_mapper.Map(command, fromDb);
		await _db.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}
