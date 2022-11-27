using Application.Trips.Commands;
using EndPlannerApp.Shared.Trips.Commands;

namespace UnitTests.Trips.Commands;

public class UpdateTripCommandHandlerTest : CommandTestBase
{
	private readonly UpdateTripCommandHandler _handler;
	public UpdateTripCommandHandlerTest()
	{
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task UpdateTest()
	{
		UpdateTripCommand command = new()
		{
			Id = 1,
			Name = "the new baltic"
		};
		await _handler.Handle(command, _token);
		var fromDb = await _db.Trips.SingleOrDefaultAsync(m => m.Id == command.Id);
		fromDb.Name.ShouldBe("the new baltic");
	}
}
