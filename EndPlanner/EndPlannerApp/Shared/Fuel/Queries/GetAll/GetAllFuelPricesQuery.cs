namespace EndPlannerApp.Shared.Fuel.Queries.GetAll;
public class GetAllFuelPricesQuery: IRequest<GetAllFuelPricesVm>
{
	public string FuelCode { get; set; } = "";
}
