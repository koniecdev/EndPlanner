using Application.Trips.Queries;
using EndPlannerApp.Shared.Trips.Queries;

namespace UnitTests.Trips.Queries;

[Collection("QueryCollection")]
public class GetTripQueryHandlerTest
{
	private readonly IEndPlannerDbContext _db;
	private readonly IMapper _mapper;
	private readonly GetTripQueryHandler _handler;
	public GetTripQueryHandlerTest(QueryTestFixtures fixtures)
	{
		_db = fixtures.Context;
		_mapper = fixtures.Mapper;
		_handler = new(_db, _mapper);
	}

	[Fact]
	public async Task GetCountriesTest()
	{
		GetTripQuery query = new()
		{
			Id = 1
		};
		var response = await _handler.Handle(query, CancellationToken.None);
		response.Rules.Count.ShouldBe(1);
	}

}
