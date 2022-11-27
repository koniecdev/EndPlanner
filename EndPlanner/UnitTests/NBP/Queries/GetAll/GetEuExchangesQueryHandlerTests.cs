using Application.NBP.Queries.GetAll;
using Application.NBP.Queries.GetBy;
using EndPlannerApp.Shared.NBP.Queries.GetBy;
using Persistance;

namespace UnitTests.NBP.Queries.GetAll;

[Collection("QueryCollection")]
public class GetEuExchangesQueryHandlerTests
{
	private readonly EndPlannerDbContext _db;
	private readonly IMapper _mapper;
	private readonly INBPClient _NBP;
	public GetEuExchangesQueryHandlerTests(QueryTestFixtures fixtures)
	{
		_db = fixtures.Context;
		_mapper = fixtures.Mapper;
		_NBP = fixtures.NBPClient;
	}

	[Fact]
	public async Task NBPGetAllExchangesTest()
	{
		var handler = new GetEuExchangesQueryHandler(_NBP, _mapper);
		var result = await handler.Handle(new EndPlannerApp.Shared.NBP.Queries.GetAll.GetEuExchangesQuery(), CancellationToken.None);
		result.ShouldNotBeNull();
	}

	[Fact]
	public async Task NBPGetExchangeByCodeTest()
	{
		var handler = new GetEuExchangeByCodeQueryHandler(_NBP, _mapper);
		var result = await handler.Handle(new GetEuExchangeQuery() { CurrencyCode = "USD"}, CancellationToken.None);
		result.Code.ShouldBe("USD");
	}
}
