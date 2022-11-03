using Application.Common.Interfaces;
using Application.NBP.Queries.GetAll;
using Application.NBP.Queries.GetBy;
using AutoMapper;
using EndPlannerApp.Shared.Fuel.Queries.GetAll;
using EndPlannerApp.Shared.Fuel.Queries.GetSelected;
using EndPlannerApp.Shared.NBP.Queries.GetBy;
using Persistance;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.NBP.Queries.GetAll;

[Collection("QueryCollection")]
public class GetAllFuelPricesQueryHandlerTest
{
	private readonly EndPlannerDbContext _db;
	private readonly IMapper _mapper;
	private readonly IFuelPricesClient _Fuel;
	public GetAllFuelPricesQueryHandlerTest(QueryTestFixtures fixtures)
	{
		_db = fixtures.Context;
		_mapper = fixtures.Mapper;
		_Fuel = fixtures.FuelPricesClient;
	}

	[Fact]
	public async Task FuelGetAllExchangesTest()
	{
		var handler = new GetAllFuelPricesQueryHandler(_mapper, _Fuel);
		var result = await handler.Handle(new GetAllFuelPricesQuery() { FuelCode = "95" }, CancellationToken.None);
		result.ShouldNotBeNull();
	}

	[Fact]
	public async Task FuelGetSelectedExchangesTest()
	{
		var handler = new GetSelectedFuelPricesQueryHandler(_Fuel, _mapper);
		var result = await handler.Handle(new GetSelectedFuelPricesQuery() { FuelType = "95", ProvidedCountries = "DEU,SWE" }, CancellationToken.None);
		result.FuelExchanges.Count.ShouldBe(2);
	}


}
