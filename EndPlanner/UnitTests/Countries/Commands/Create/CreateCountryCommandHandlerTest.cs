using Application.Countries.Commands;
using EndPlannerApp.Shared.Countries.Commands;

namespace UnitTests.Countries.Commands;

public class CreateCountryCommandHandlerTest : CommandTestBase
{
	private readonly CreateCountryCommandHandler _handler;
	public CreateCountryCommandHandlerTest()
	{
		_handler = new(_mapper, _db);
	}

	[Fact]
	public async Task CreateCountryTest()
	{
		CreateCountryCommand member = new()
		{
			Name = "Italy",
			CountryCode = "IT",
			CountryCode3 = "ITA",
			CurrencyCode = "EUR"
		};
		int response = await _handler.Handle(member, _token);
		response.ShouldBeGreaterThan(0);
	}
}
