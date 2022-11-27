using EndPlannerApp.Shared.Rules.Commands;

namespace Application.Rules.Commands;
public class CreateRuleCommandHandler : IRequestHandler<CreateRuleCommand, int>
{
	private readonly IEndPlannerDbContext _db;
	private readonly IMapper _mapper;
	public CreateRuleCommandHandler(IMapper mapper, IEndPlannerDbContext db)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<int> Handle(CreateRuleCommand command, CancellationToken cancellationToken)
	{
		Rule? newRule = _mapper.Map<Rule>(command);
		if(newRule == null)
		{
			throw new MappingException(nameof(CreateRuleCommand), new Exception());
		}
		_db.Rules.Add(newRule);
		await _db.SaveChangesAsync(cancellationToken);
		return newRule.Id;
	}
}
