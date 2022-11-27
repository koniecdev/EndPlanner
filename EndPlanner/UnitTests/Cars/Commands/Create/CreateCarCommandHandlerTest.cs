using Application.Cars.Commands;
using EndPlannerApp.Shared.Cars.Commands;

namespace UnitTests.Cars.Commands;

public class CreateCarCommandHandlerTest : CommandTestBase
{
	private readonly CreateCarCommandHandler _handler;
	public CreateCarCommandHandlerTest()
	{
		_handler = new(_mapper, _db);
	}

	[Fact]
	public async Task CreateCarTest()
	{
		CreateCarCommand member = new()
		{
			Name = "GOlf V",
			MemberId = 1,
			FuelConsumption = 6,
			FuelType = 0,
			Seats = 5,
			TankLiters = 55
		};
		int response = await _handler.Handle(member, _token);
		response.ShouldBeGreaterThan(0);
	}
}
