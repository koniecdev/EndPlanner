namespace Application.Common.Interfaces;

public interface IFuelPricesClient
{
	IDictionary<string, string> FuelType { get; }
	Task<List<Tuple<string, double>>> GetAllEuropeanCountryPrices(string fuelType, CancellationToken cancellationToken);
}
