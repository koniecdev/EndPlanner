using Microsoft.AspNetCore.Mvc;

namespace EndPlanner.Controllers;

[Route("api/countries")]
public class CountriesController : BaseController
{
	//[HttpGet]
	//public async Task<ActionResult<GetCountriesVm>> Country()
	//{
	//	var response = await Mediator.Send(new GetCountriesQuery());
	//	return Ok(response);
	//}
	//[HttpPost]
	//public async Task<ActionResult<int>> Country(CreateCountryCommand command)
	//{
	//	try
	//	{
	//		var response = await Mediator.Send(command);
	//		return Ok(response);
	//	}
	//	catch (Exception)
	//	{
	//		return ValidationProblem();
	//	}
	//}
	//[HttpPatch]
	//public async Task<ActionResult> Country(UpdateCountryCommand command)
	//{
	//	try
	//	{
	//		await Mediator.Send(command);
	//		return NoContent();
	//	}
	//	catch (Exception)
	//	{
	//		return ValidationProblem();
	//	}
	//}
	//[HttpDelete("{id}")]
	//public async Task<ActionResult> Country(int id)
	//{
	//	try
	//	{
	//		await Mediator.Send(new DeleteCountryCommand() { Id = id });
	//		return NoContent();
	//	}
	//	catch (Exception)
	//	{
	//		return ValidationProblem();
	//	}
	//}
}
