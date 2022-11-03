using Domain.Entities.Fuel;

namespace EndPlannerApp.Shared.Fuel.Queries.GetAll;

public class GetAllFuelPricesVm
{
	public ICollection<GetAllFuelPricesDto> FuelExchanges { get; set; }
}
