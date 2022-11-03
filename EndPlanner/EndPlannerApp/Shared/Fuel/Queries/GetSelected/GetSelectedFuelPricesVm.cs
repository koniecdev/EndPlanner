using Domain.Entities.Fuel;

namespace EndPlannerApp.Shared.Fuel.Queries.GetSelected;

public class GetSelectedFuelPricesVm
{
	public ICollection<GetSelectedFuelPricesDto> FuelExchanges { get; set; }
	
}
