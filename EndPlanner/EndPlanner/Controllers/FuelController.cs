using EndPlannerApp.Shared.Fuel.Queries.GetAll;
using EndPlannerApp.Shared.Fuel.Queries.GetSelected;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPlanner.Controllers;

[Route("api/fuels")]
public class FuelController : BaseController
{
	[HttpGet]
	[Route("{fuelCode}")]
	public async Task<ActionResult<GetAllFuelPricesVm>> Fuel(string fuelCode)
	{
		var response = await Mediator.Send(new GetAllFuelPricesQuery() { FuelCode = fuelCode});
		return response;
	}

	[HttpGet]
	[AllowAnonymous]
	[Route("{fuelCode}/{commaSeperatedCountries}")]
	public async Task<ActionResult<GetSelectedFuelPricesVm>> GetMemberTripsCarsVm(string fuelCode, string commaSeperatedCountries)
	{
		var response = await Mediator.Send(new GetSelectedFuelPricesQuery() { FuelType = fuelCode, ProvidedCountries = commaSeperatedCountries });
		return response;
	}

	//[HttpPost]
	//public async Task<ActionResult<int>> Member(CreateMemberCommand command)
	//{
	//	int response = await Mediator.Send(command);
	//	return response;
	//}
}
