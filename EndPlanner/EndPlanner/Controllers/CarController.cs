using Microsoft.AspNetCore.Mvc;

namespace EndPlanner.Controllers;

[Route("api/cars")]
public class CarController : BaseController
{
	//[HttpPost]
	//public async Task<ActionResult<int>> Car(CreateCarCommand command)
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
	//public async Task<ActionResult> Car(UpdateCarCommand command)
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
	//public async Task<ActionResult> Car(int id)
	//{
	//	try
	//	{
	//		await Mediator.Send(new DeleteCarCommand() { Id = id });
	//		return NoContent();
	//	}
	//	catch (Exception)
	//	{
	//		return ValidationProblem();
	//	}
	//}
}
