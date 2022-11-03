using Domain.Entities.Fuel;

namespace Application.Common.Interfaces;

public interface IFuelPricesClient
{
	IDictionary<string, string> FuelType { get; }
	Task<List<FuelData>> GetAllEuropeanCountryPrices(string fuelType, CancellationToken cancellationToken);
	Task<List<FuelData>> GetSelectedEuropeanCountryPrices(string fuelType, string providedCountries, CancellationToken cancellationToken);
}
