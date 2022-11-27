using Application.Rules.Commands;
using EndPlannerApp.Shared.Rules.Commands;

namespace UnitTests.Rules.Commands;

public class DeleteRuleCommandHandlerTest : CommandTestBase
{
	private readonly DeleteRuleCommandHandler _handler;
	public DeleteRuleCommandHandlerTest()
	{
		_handler = new(_db);
	}

	[Fact]
	public async Task DeleteRuleTest()
	{
		DeleteRuleCommand rule = new()
		{
			Id = 1
		};
		await _handler.Handle(rule, _token);
		var fromDb = await _db.Rules.FirstOrDefaultAsync(m => m.Id == 1 && m.StatusId == 1);
		fromDb.ShouldBeNull();
	}
}
