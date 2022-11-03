using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Fuel;
using Ganss.Excel;
using System.Text;
using System.Text.RegularExpressions;

namespace Infrastructure.ExternalAPIs.FuelPrices;

public partial class FuelPricesClient : IFuelPricesClient
{
	private readonly IFileStore _fileStore;
	public IDictionary<string, string> FuelType { get; }
	public FuelPricesClient(IFileStore fileStore)
	{
		_fileStore = fileStore;
		FuelType = new Dictionary<string, string>
		{
			{ "ON", "Automotive gas oil" },
			{ "95", "Euro-super 95" },
			{ "LPG", "LPG - motor fuel" },
			{ "98", "Heating gas oil" }
		};
	}

	public async Task<List<FuelData>> GetSelectedEuropeanCountryPrices(string fuelType, string providedCountries, CancellationToken cancellationToken)
	{
		List<string> formattedCountries = Regex.Replace(providedCountries, @"\s+", "").ToUpper().Split(",").ToList();
		string dataPath = await DownloadFreshFile(cancellationToken);
		Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
		var products = new ExcelMapper(dataPath).Fetch<Fuel>().ToList();
		if (string.IsNullOrWhiteSpace(fuelType))
		{
			throw new NotFoundException(fuelType, new Exception());
		}
		if (formattedCountries.Count == 0)
		{
			throw new NotFoundException("countries in string does not exsits", new Exception());
		}
		var fromSheet = products.Where(m => m.FuelName.Contains(FuelType[fuelType]) && formattedCountries.Any(x=>x.Contains(m.CountryCode))).ToList();
		List<FuelData> data = new();
		var _pl = products.FirstOrDefault(m => m.CountryCode.Contains("PL"));
		foreach (var country in fromSheet)
		{
			double WeeklyPrice = double.Parse(country.WeeklyPricesWithTax.Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture);
			double PricesUnit = double.Parse(country.PricesUnit.Replace("L", ""), System.Globalization.CultureInfo.InvariantCulture);
			double EuroExchangeRate = double.Parse(_pl.EuroExchangeRate, System.Globalization.CultureInfo.InvariantCulture);
			double PriceInPln = WeeklyPrice / EuroExchangeRate;
			double PricePerLiter = Math.Round((PriceInPln / PricesUnit), 2, MidpointRounding.AwayFromZero);
			data.Add(new FuelData() { CountryName = country.CountryName, CountryCode = country.CountryCode, Date = country.Date, PricePerLiter = PricePerLiter });
		}
		return data;
	}

	public async Task<List<FuelData>> GetAllEuropeanCountryPrices(string fuelType, CancellationToken cancellationToken)
    {
		string dataPath = await DownloadFreshFile(cancellationToken);
		Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
		var products = new ExcelMapper(dataPath).Fetch<Fuel>().ToList();
		if (FuelType[fuelType] == null)
		{
			throw new Exception();
		}
		var fromSheat = products.Where(m => m.FuelName.Contains(FuelType[fuelType])).ToList();

		List<FuelData> data = new();
		var _pl = fromSheat.FirstOrDefault(m => m.CountryCode.Contains("PL"));
		foreach (var country in fromSheat)
		{
			double WeeklyPrice = double.Parse(country.WeeklyPricesWithTax.Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture);
			double PricesUnit = double.Parse(country.PricesUnit.Replace("L", ""), System.Globalization.CultureInfo.InvariantCulture);
			double EuroExchangeRate = double.Parse(_pl.EuroExchangeRate, System.Globalization.CultureInfo.InvariantCulture);
			double PriceInPln = WeeklyPrice / EuroExchangeRate;
			double PricePerLiter = Math.Round((PriceInPln / PricesUnit), 2, MidpointRounding.AwayFromZero);
			data.Add(new FuelData() { CountryName = country.CountryName, CountryCode = country.CountryCode, Date = country.Date, PricePerLiter = PricePerLiter});
		}
		return data;
	}

	private async Task<string> DownloadFreshFile(CancellationToken cancellationToken)
	{
		using (var client = new HttpClient())
		{
			using (var apiResponse = await client.GetAsync("https://ec.europa.eu/energy/observatory/reports/latest_prices_raw_data.xlsx", cancellationToken))
			{
				var fromStr = await apiResponse.Content.ReadAsByteArrayAsync(cancellationToken);
				var dataPath = _fileStore.SafeWriteFile(fromStr, "fueldata.xlsx", "/MyStaticFiles");
				return dataPath;
			}
		}
	}
}
