global using System.Linq;
global using Microsoft.EntityFrameworkCore;
using Application.Cars.Commands;
using EndPlannerApp.Shared.Cars.Commands;

namespace UnitTests.Members.Commands;

public class UpdateCarCommandHandlerTest : CommandTestBase
{
	private readonly UpdateCarCommandHandler _handler;
	public UpdateCarCommandHandlerTest()
	{
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task UpdateCarTest()
	{
		var fromDb = await _db.Cars.SingleAsync(m => m.Id == 1);
		UpdateCarCommand car = new()
		{
			Id = 1,
			Seats = 7
		};
		await _handler.Handle(car, _token);
		(fromDb.TankLiters == 60 && fromDb.Seats == 7).ShouldBeTrue();
	}
}
