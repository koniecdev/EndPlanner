global using Application.Common.Interfaces;
global using AutoMapper;
using Application.Members.Queries;
using EndPlannerApp.Shared.Members.Queries;

namespace UnitTests.Members.Queries;

[Collection("QueryCollection")]
public class GetMemberTripsCarsQueryHandlerTest
{
	private readonly IEndPlannerDbContext _db;
	private readonly IMapper _mapper;
	private readonly GetMemberTripsCarsQueryHandler _handler;
	public GetMemberTripsCarsQueryHandlerTest(QueryTestFixtures fixtures)
	{
		_db = fixtures.Context;
		_mapper = fixtures.Mapper;
		_handler = new(_mapper, _db);
	}

	[Fact]
	public async Task GetMemberTripsCarsQueryTest()
	{
		GetMemberTripsCarsQuery query = new() { UserId = "UserIdOfMember" };
		var response = await _handler.Handle(query, CancellationToken.None);
		response.Cars.Count.ShouldBe(2);
	}

}
