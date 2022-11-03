namespace EndPlannerApp.Shared.Fuel.Queries.GetSelected;
public class GetSelectedFuelPricesQuery : IRequest<GetSelectedFuelPricesVm>
{
	public string FuelType { get; set; } = "";
	public string ProvidedCountries { get; set; } = "";
}
