using Microsoft.AspNetCore.Mvc;

namespace EndPlanner.Controllers;

[Route("api/routes")]
public class RouteController : BaseController
{
	//[HttpGet("{id}")]
	//public async Task<ActionResult<GetRouteVm>> RouteById(int id)
	//{
	//	var response = await Mediator.Send(new GetRouteQuery { Id = id });
	//	return Ok(response);
	//}
	//[HttpPost]
	//public async Task<ActionResult<int>> Route(CreateRouteCommand command)
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
	//public async Task<ActionResult> Route(UpdateRouteCommand command)
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
	//public async Task<ActionResult> Route(int id)
	//{
	//	try
	//	{
	//		await Mediator.Send(new DeleteRouteCommand() { Id = id });
	//		return NoContent();
	//	}
	//	catch (Exception)
	//	{
	//		return ValidationProblem();
	//	}
	//}
}
