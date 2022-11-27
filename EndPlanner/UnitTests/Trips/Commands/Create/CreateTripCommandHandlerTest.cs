using Application.Trips.Commands;
using EndPlannerApp.Shared.Trips.Commands;

namespace UnitTests.Trips.Commands;

public class CreateTripCommandHandlerTest : CommandTestBase
{
	private readonly CreateTripCommandHandler _handler;
	public CreateTripCommandHandlerTest()
	{
		_handler = new(_mapper, _db);
	}

	[Fact]
	public async Task CreateTripTest()
	{
		CreateTripCommand car = new()
		{
			Address = new()
			{
				City = "xdxdxd",
				House = "xdxdxd",
				PostalCode = "xdxdxd",
				Street = "xdxdxd"
			},
			DriversAvailable = 2,
			CarId = 1,
			StartingDate = _dateTime.Now,
			Name = "Fajny trip"
		};
		var id = await _handler.Handle(car, CancellationToken.None);
		var fromDb = await _db.Trips.SingleOrDefaultAsync(m => m.Id == id);
		fromDb.ShouldNotBeNull();
	}
}
