using Application.Countries.Commands;
using EndPlannerApp.Shared.Countries.Commands;

namespace UnitTests.Countries.Commands;

public class DeleteCountryCommandHandlerTest : CommandTestBase
{
	private readonly DeleteCountryCommandHandler _handler;
	public DeleteCountryCommandHandlerTest()
	{
		_handler = new(_db);
	}

	[Fact]
	public async Task DeleteCountryTest()
	{
		DeleteCountryCommand member = new()
		{
			Id = 1
		};
		await _handler.Handle(member, _token);
		var fromDb = await _db.Countries.FirstOrDefaultAsync(m => m.Id == 1 && m.StatusId == 1);
		fromDb.ShouldBeNull();
	}
}
