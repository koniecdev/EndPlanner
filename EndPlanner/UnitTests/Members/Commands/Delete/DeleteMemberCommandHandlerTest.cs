using Application.Members.Commands;
using EndPlannerApp.Shared.Members.Commands;

namespace UnitTests.Members.Commands;

public class DeleteMemberCommandHandlerTest : CommandTestBase
{
	private readonly DeleteMemberCommandHandler _handler;
	public DeleteMemberCommandHandlerTest()
	{
		_handler = new(_db);
	}

	[Fact]
	public async Task DeleteMemberTest()
	{
		DeleteMemberCommand member = new()
		{
			Id = 1
		};
		await _handler.Handle(member, _token);
		var fromDb = await _db.Members.FirstOrDefaultAsync(m => m.Id == 1 && m.StatusId == 1);
		fromDb.ShouldBeNull();
	}
}
