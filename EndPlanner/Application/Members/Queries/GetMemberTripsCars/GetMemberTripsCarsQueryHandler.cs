using EndPlannerApp.Shared.Members.Queries;

namespace Application.Members.Queries;

public class GetMemberTripsCarsQueryHandler : IRequestHandler<GetMemberTripsCarsQuery, GetMemberTripsCarsVm>
{
	private readonly IEndPlannerDbContext _db;
	private readonly IMapper _mapper;
	public GetMemberTripsCarsQueryHandler(IMapper mapper, IEndPlannerDbContext db)
	{
		_mapper = mapper;
		_db = db;
	}
	public async Task<GetMemberTripsCarsVm> Handle(GetMemberTripsCarsQuery request, CancellationToken cancellationToken)
	{
		var fromDb = await _db.Members.SingleOrDefaultAsync(m => m.UserId == request.UserId);
		if(fromDb == null)
		{
			throw new NotFoundException(request.UserId, new Exception());
		}
		var mapped = _mapper.Map<GetMemberTripsCarsVm>(fromDb);
		if(mapped == null)
		{
			throw new MappingException(nameof(GetMemberTripsCarsVm), new Exception());
		}
		return mapped;
	}
}
