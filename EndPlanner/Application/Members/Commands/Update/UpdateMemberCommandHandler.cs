using EndPlannerApp.Shared.Members.Commands;

namespace Application.Members.Commands;
public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, Unit>
{
	private readonly IEndPlannerDbContext _db;
	private readonly IMapper _mapper;
	public UpdateMemberCommandHandler(IEndPlannerDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<Unit> Handle(UpdateMemberCommand command, CancellationToken cancellationToken)
	{
		Member? member = await _db.Members.SingleOrDefaultAsync(m => m.Id == command.Id, cancellationToken);
		if(member == null)
		{
			throw new NotFoundException(command.Id.ToString(), new Exception());
		}
		_mapper.Map(command, member);
		if(member.UserEmail != command.UserEmail)
		{
			throw new MappingException(nameof(UpdateMemberCommand), new Exception());
		}
		await _db.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}
