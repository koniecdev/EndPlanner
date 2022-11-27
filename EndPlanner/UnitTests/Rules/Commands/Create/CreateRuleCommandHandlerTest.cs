using Application.Rules.Commands;
using EndPlannerApp.Shared.Rules.Commands;

namespace UnitTests.Rules.Commands;

public class CreateRuleCommandHandlerTest : CommandTestBase
{
	private readonly CreateRuleCommandHandler _handler;
	public CreateRuleCommandHandlerTest()
	{
		_handler = new(_mapper, _db);
	}

	[Fact]
	public async Task CreateRuleTest()
	{
		CreateRuleCommand rule = new()
		{
			Description = "You musn't pull over on autobahn",
			CountryId = 2,
			TripId = 1
		};
		var id = await _handler.Handle(rule, CancellationToken.None);
		var fromDb = await _db.Rules.SingleOrDefaultAsync(m => m.Id == id);
		fromDb.Description.ShouldBe("You musn't pull over on autobahn");
	}
}
