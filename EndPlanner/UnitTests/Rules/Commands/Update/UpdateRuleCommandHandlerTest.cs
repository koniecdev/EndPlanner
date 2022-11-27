using Application.Rules.Commands;
using EndPlannerApp.Shared.Rules.Commands;

namespace UnitTests.Rules.Commands;

public class UpdateRuleCommandHandlerTest : CommandTestBase
{
	private readonly UpdateRuleCommandHandler _handler;
	public UpdateRuleCommandHandlerTest()
	{
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task UpdateRuleTest()
	{
		UpdateRuleCommand command = new()
		{
			Id = 1,
			CountryId = 2,
		};
		await _handler.Handle(command, _token);
		var fromDb = await _db.Rules.SingleOrDefaultAsync(m => m.Id == command.Id);
		fromDb.CountryId.ShouldBe(2);
	}
}
