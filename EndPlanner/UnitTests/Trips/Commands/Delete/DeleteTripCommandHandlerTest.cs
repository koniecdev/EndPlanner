using Application.Trips.Commands;
using EndPlannerApp.Shared.Trips.Commands;

namespace UnitTests.Trips.Commands;

public class DeleteTripCommandHandlerTest : CommandTestBase
{
	private readonly DeleteTripCommandHandler _handler;
	public DeleteTripCommandHandlerTest()
	{
		_handler = new(_db);
	}

	[Fact]
	public async Task DeleteTripTest()
	{
		DeleteTripCommand member = new()
		{
			Id = 1
		};
		await _handler.Handle(member, _token);
		var fromDb = await _db.Trips.FirstOrDefaultAsync(m => m.Id == 1 && m.StatusId == 1);
		fromDb.ShouldBeNull();
	}
}
