using Domain.Entities.Fuel;
using Domain.Entities.NBP;
using EndPlannerApp.Shared.Common.Mappings;
using Moq;
using Newtonsoft.Json;
using Persistance;
using System;
using System.Collections.Generic;
namespace UnitTests;

public class QueryTestFixtures : IDisposable
{
	public EndPlannerDbContext Context { get; private set; }
	public IMapper Mapper { get; private set; }
	public INBPClient NBPClient { get; private set; }
	public IFuelPricesClient FuelPricesClient { get; private set; }
	public QueryTestFixtures()
	{
		Context = EndPlannerDbContextFactory.Create().Object;
		var configurationProvider = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile<MappingProfile>();
		});
		Mapper = configurationProvider.CreateMapper();
		
		var NBPClientMock = new Mock<INBPClient>();
		string jsonFile = "{\"table\":\"A\",\"no\":\"211/A/NBP/2022\",\"effectiveDate\":\"2022-10-31\",\"rates\":[{\"currency\":\"bat(Tajlandia)\",\"code\":\"THB\",\"mid\":0.1243},{\"currency\":\"dolaramerykański\",\"code\":\"USD\",\"mid\":4.7340},{\"currency\":\"dolaraustralijski\",\"code\":\"AUD\",\"mid\":3.0316},{\"currency\":\"dolarHongkongu\",\"code\":\"HKD\",\"mid\":0.6031},{\"currency\":\"dolarkanadyjski\",\"code\":\"CAD\",\"mid\":3.4700},{\"currency\":\"dolarnowozelandzki\",\"code\":\"NZD\",\"mid\":2.7530},{\"currency\":\"dolarsingapurski\",\"code\":\"SGD\",\"mid\":3.3471},{\"currency\":\"euro\",\"code\":\"EUR\",\"mid\":4.7089},{\"currency\":\"forint(Węgry)\",\"code\":\"HUF\",\"mid\":0.011457},{\"currency\":\"frankszwajcarski\",\"code\":\"CHF\",\"mid\":4.7376},{\"currency\":\"funtszterling\",\"code\":\"GBP\",\"mid\":5.4748},{\"currency\":\"hrywna(Ukraina)\",\"code\":\"UAH\",\"mid\":0.1258},{\"currency\":\"jen(Japonia)\",\"code\":\"JPY\",\"mid\":0.031897},{\"currency\":\"koronaczeska\",\"code\":\"CZK\",\"mid\":0.1922},{\"currency\":\"koronaduńska\",\"code\":\"DKK\",\"mid\":0.6326},{\"currency\":\"koronaislandzka\",\"code\":\"ISK\",\"mid\":0.03286},{\"currency\":\"koronanorweska\",\"code\":\"NOK\",\"mid\":0.4581},{\"currency\":\"koronaszwedzka\",\"code\":\"SEK\",\"mid\":0.4313},{\"currency\":\"kuna(Chorwacja)\",\"code\":\"HRK\",\"mid\":0.6252},{\"currency\":\"lejrumuński\",\"code\":\"RON\",\"mid\":0.9580},{\"currency\":\"lew(Bułgaria)\",\"code\":\"BGN\",\"mid\":2.4076},{\"currency\":\"liraturecka\",\"code\":\"TRY\",\"mid\":0.2543},{\"currency\":\"nowyizraelskiszekel\",\"code\":\"ILS\",\"mid\":1.3393},{\"currency\":\"pesochilijskie\",\"code\":\"CLP\",\"mid\":0.005018},{\"currency\":\"pesofilipińskie\",\"code\":\"PHP\",\"mid\":0.0815},{\"currency\":\"pesomeksykańskie\",\"code\":\"MXN\",\"mid\":0.2384},{\"currency\":\"rand(RepublikaPołudniowejAfryki)\",\"code\":\"ZAR\",\"mid\":0.2589},{\"currency\":\"real(Brazylia)\",\"code\":\"BRL\",\"mid\":0.8938},{\"currency\":\"ringgit(Malezja)\",\"code\":\"MYR\",\"mid\":1.0013},{\"currency\":\"rupiaindonezyjska\",\"code\":\"IDR\",\"mid\":0.00030351},{\"currency\":\"rupiaindyjska\",\"code\":\"INR\",\"mid\":0.05717},{\"currency\":\"wonpołudniowokoreański\",\"code\":\"KRW\",\"mid\":0.003315},{\"currency\":\"yuanrenminbi(Chiny)\",\"code\":\"CNY\",\"mid\":0.6487},{\"currency\":\"SDR(MFW)\",\"code\":\"XDR\",\"mid\":6.0827}]}";
		string jsonFile2 = "{\"table\":\"A\",\"currency\":\"dolar amerykański\",\"code\":\"USD\",\"rates\":[{\"no\":\"212/A/NBP/2022\",\"effectiveDate\":\"2022-11-02\",\"mid\":4.7485}]}";
		//var fle = File.ReadAllText(@"C:\Users\Ariteku\source\repos\EndPlanner\EndPlanner\UnitTests\Common\apinbppl.json");
		EuExchangesData fakeResponse = JsonConvert.DeserializeObject<EuExchangesData>(/*fle.Substring(1, fle.Length - 2)*/jsonFile);
		EuExchangeCurrency fakeResponse2 = JsonConvert.DeserializeObject<EuExchangeCurrency>(jsonFile2);
		NBPClientMock.Setup(m => m.GetAllPlnExchangeRates(CancellationToken.None)).ReturnsAsync(fakeResponse);
		NBPClientMock.Setup(m => m.GetExchangeRateByCurrency("USD",CancellationToken.None)).ReturnsAsync(fakeResponse2);
		NBPClient = NBPClientMock.Object;

		var FuelClientMock = new Mock<IFuelPricesClient>();
		List<FuelData> fakeFuelData = new();
		fakeFuelData.Add(new FuelData()
		{
			CountryCode = "DEU",
			Date = "2022/11/02",
			CountryName = "Germany",
			PricePerLiter = 9.22
		});
		fakeFuelData.Add(new FuelData()
		{
			CountryCode = "DNK",
			Date = "2022/11/02",
			CountryName = "Denmark",
			PricePerLiter = 9.83
		});
		fakeFuelData.Add(new FuelData()
		{
			CountryCode = "SWE",
			Date = "2022/11/02",
			CountryName = "Sweden",
			PricePerLiter = 9.12
		});
		FuelClientMock.Setup(m => m.GetAllEuropeanCountryPrices("95", CancellationToken.None)).ReturnsAsync(fakeFuelData);
		var selectedFakeFuelData = fakeFuelData.Where(m => m.CountryCode == "DEU" || m.CountryCode == "SWE").ToList();
		FuelClientMock.Setup(m => m.GetSelectedEuropeanCountryPrices("95", "DEU,SWE", CancellationToken.None)).ReturnsAsync(selectedFakeFuelData);
		FuelPricesClient = FuelClientMock.Object;
	}
	public void Dispose()
	{
		EndPlannerDbContextFactory.Destroy(Context);
	}
}

[CollectionDefinition("QueryCollection")]
public class QueryCollection : ICollectionFixture<QueryTestFixtures> {  }