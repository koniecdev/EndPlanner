using Application.Countries.Commands;
using EndPlannerApp.Shared.Countries.Commands;

namespace UnitTests.Countries.Commands;

public class UpdateCountryCommandHandlerTest : CommandTestBase
{
	private readonly UpdateCountryCommandHandler _handler;
	public UpdateCountryCommandHandlerTest()
	{
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task UpdateCarTest()
	{
		var fromDb = await _db.Countries.SingleAsync(m => m.Id == 1);
		UpdateCountryCommand car = new()
		{
			Id = 1,
			CurrencyCode = "PLN"
		};
		await _handler.Handle(car, _token);
		(fromDb.CountryCode3 == "FRA" && fromDb.CurrencyCode == "PLN").ShouldBeTrue();
	}
}
