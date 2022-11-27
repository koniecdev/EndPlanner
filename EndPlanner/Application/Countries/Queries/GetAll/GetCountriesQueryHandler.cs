using EndPlannerApp.Shared.Countries.Queries;

namespace Application.Countries.Queries;
public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, GetCountriesVm>
{
	private readonly IEndPlannerDbContext _db;
	private readonly IMapper _mapper;
	public GetCountriesQueryHandler(IEndPlannerDbContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<GetCountriesVm> Handle(GetCountriesQuery command, CancellationToken cancellationToken)
	{
		List<Country> fromDb = await _db.Countries.ToListAsync(cancellationToken);
		//if(fromDb == null)
		//{
		//	return new GetCountriesVm();
		//}
		GetCountriesVm vm = new() { Countries = _mapper.Map<List<GetCountriesDto>>(fromDb)};
		if(vm.Countries == null)
		{
			throw new MappingException(nameof(GetCountriesDto), new Exception());
		}
		return vm;
	}
}
