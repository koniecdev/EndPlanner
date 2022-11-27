using EndPlannerApp.Shared.Countries.Commands;

namespace Application.Countries.Commands;
public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, int>
{
	private readonly IEndPlannerDbContext _db;
	private readonly IMapper _mapper;
	public CreateCountryCommandHandler(IMapper mapper, IEndPlannerDbContext db)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<int> Handle(CreateCountryCommand command, CancellationToken cancellationToken)
	{
		Country country = _mapper.Map<Country>(command);
		if(country == null)
		{
			throw new MappingException(nameof(CreateCountryCommand), new Exception());
		}
		_db.Countries.Add(country);
		await _db.SaveChangesAsync(cancellationToken);
		return country.Id;
	}
}
