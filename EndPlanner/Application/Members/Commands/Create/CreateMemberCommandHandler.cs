using EndPlannerApp.Shared.Members.Commands;

namespace Application.Members.Commands;
public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, int>
{
	private readonly IEndPlannerDbContext _db;
	private readonly IMapper _mapper;
	public CreateMemberCommandHandler(IMapper mapper, IEndPlannerDbContext db)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<int> Handle(CreateMemberCommand command, CancellationToken cancellationToken)
	{
		Member? member = _mapper.Map<Member>(command);
		if(member == null)
		{
			throw new MappingException(nameof(CreateMemberCommand), new Exception());
		}
		_db.Members.Add(member);
		await _db.SaveChangesAsync(cancellationToken);
		if(member.Id == 0)
		{
			throw new DatabaseException(member.Id.ToString(), new Exception());
		}
		return member.Id;
	}
}
