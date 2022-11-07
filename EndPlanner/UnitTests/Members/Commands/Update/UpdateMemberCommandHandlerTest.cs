global using System.Linq;
global using Microsoft.EntityFrameworkCore;
using Application.Members.Commands;
using EndPlannerApp.Shared.Members.Commands;

namespace UnitTests.Members.Commands;

public class UpdateMemberCommandHandlerTest : CommandTestBase
{
	private readonly UpdateMemberCommandHandler _handler;
	public UpdateMemberCommandHandlerTest()
	{
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task UpdateMemberTest()
	{
		UpdateMemberCommand member = new()
		{
			Id = 1,
			UserEmail = "dummyEdited@mail.com",
		};
		await _handler.Handle(member, _token);
		var fromDb = await _db.Members.SingleAsync(m => m.Id == 1);
		fromDb.UserEmail.ShouldBe("dummyEdited@mail.com");
	}
}
