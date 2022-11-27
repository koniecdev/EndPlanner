using EndPlannerApp.Shared.Trips.Queries;

namespace Application.Trips.Queries;
public class GetTripQueryHandler : IRequestHandler<GetTripQuery, GetTripVm>
{
	private readonly IEndPlannerDbContext _db;
	private readonly IMapper _mapper;
	public GetTripQueryHandler(IEndPlannerDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<GetTripVm> Handle(GetTripQuery query, CancellationToken cancellationToken)
	{
		Trip? fromDb = await _db.Trips
			.Include(m=>m.Car).SingleOrDefaultAsync(m => m.Id == query.Id, cancellationToken);
		if(fromDb == null)
		{
			throw new NotFoundException(query.Id.ToString(), new Exception());
		}
		GetTripVm? mapped = _mapper.Map<GetTripVm>(fromDb);
		if(mapped == null)
		{
			throw new MappingException(nameof(GetTripVm), new Exception());
		}
		return mapped;
	}
}
