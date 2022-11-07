global using System.Threading.Tasks;
global using Xunit;
global using System.Threading;
global using Shouldly;
using Application.Members.Commands;
using EndPlannerApp.Shared.Members.Commands;

namespace UnitTests.Members.Commands;

public class CreateMemberCommandHandlerTest : CommandTestBase
{
	private readonly CreateMemberCommandHandler _handler;
	public CreateMemberCommandHandlerTest()
	{
		_handler = new(_mapper, _db);
	}

	[Fact]
	public async Task CreateMemberTest()
	{
		CreateMemberCommand member = new()
		{
			UserEmail = "dummy@mail.com",
			UserId = "111-222-333-444"
		};
		int response = await _handler.Handle(member, _token);
		response.ShouldBeGreaterThan(0);
	}
}
