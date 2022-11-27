using EndPlannerApp.Shared.Rules.Commands;

namespace Application.Rules.Commands;
public class UpdateRuleCommandHandler : IRequestHandler<UpdateRuleCommand, Unit>
{
	private readonly IEndPlannerDbContext _db;
	private readonly IMapper _mapper;
	public UpdateRuleCommandHandler(IEndPlannerDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<Unit> Handle(UpdateRuleCommand command, CancellationToken cancellationToken)
	{
		var fromDb = await _db.Rules.SingleOrDefaultAsync(m => m.Id == command.Id, cancellationToken);
		if(fromDb == null)
		{
			throw new NotFoundException(command.Id.ToString(), new Exception());
		}
		_mapper.Map(command, fromDb);
		await _db.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}
