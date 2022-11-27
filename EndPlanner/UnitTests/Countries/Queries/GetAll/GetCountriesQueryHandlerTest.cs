using Application.Countries.Queries;
using EndPlannerApp.Shared.Countries.Queries;

namespace UnitTests.Countries.Queries;

[Collection("QueryCollection")]
public class GetCountriesQueryHandlerTest
{
	private readonly IEndPlannerDbContext _db;
	private readonly IMapper _mapper;
	private readonly GetCountriesQueryHandler _handler;
	public GetCountriesQueryHandlerTest(QueryTestFixtures fixtures)
	{
		_db = fixtures.Context;
		_mapper = fixtures.Mapper;
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task GetCountriesTest()
	{
		var response = await _handler.Handle(new GetCountriesQuery(), CancellationToken.None);
		response.Countries.Count.ShouldBe(2);
	}

}
