using Application.Cars.Commands;
using EndPlannerApp.Shared.Cars.Commands;

namespace UnitTests.Cars.Commands;

public class DeleteCarCommandHandlerTest : CommandTestBase
{
	private readonly DeleteCarCommandHandler _handler;
	public DeleteCarCommandHandlerTest()
	{
		_handler = new(_db);
	}

	[Fact]
	public async Task DeleteCarTest()
	{
		DeleteCarCommand member = new()
		{
			Id = 1
		};
		await _handler.Handle(member, _token);
		var fromDb = await _db.Cars.FirstOrDefaultAsync(m => m.Id == 1 && m.StatusId == 1);
		fromDb.ShouldBeNull();
	}
}
