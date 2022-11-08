using EndPlannerApp.Shared.Cars.Commands;

namespace Application.Cars.Commands;
public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, int>
{
	private readonly IEndPlannerDbContext _db;
	private readonly IMapper _mapper;
	public CreateCarCommandHandler(IMapper mapper, IEndPlannerDbContext db)
	{
		_db = db;
		_mapper = mapper;
	}
	public async Task<int> Handle(CreateCarCommand command, CancellationToken cancellationToken)
	{
		var mapped = _mapper.Map<Car>(command);
		if(mapped == null)
		{
			throw new MappingException(nameof(CreateCarCommand), new Exception());
		}
		_db.Cars.Add(mapped);
		await _db.SaveChangesAsync(cancellationToken);
		return mapped.Id;
	}
}
