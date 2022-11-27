using EndPlannerApp.Shared.Trips.Commands;

namespace Application.Trips.Commands;
public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, int>
{
	private readonly IEndPlannerDbContext _db;
	private readonly IMapper _mapper;
	public CreateTripCommandHandler(IMapper mapper, IEndPlannerDbContext db)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<int> Handle(CreateTripCommand command, CancellationToken cancellationToken)
	{
		Trip? newTrip = _mapper.Map<Trip>(command);
		if(newTrip == null)
		{
			throw new MappingException(nameof(CreateTripCommand), new Exception());
		}
		_db.Trips.Add(newTrip);
		await _db.SaveChangesAsync(cancellationToken);
		return newTrip.Id;
	}
}
