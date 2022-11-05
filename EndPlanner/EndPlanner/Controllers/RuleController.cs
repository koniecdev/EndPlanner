using Microsoft.AspNetCore.Mvc;

namespace EndPlanner.Controllers;

[Route("api/rules")]
public class RulesController : BaseController
{
	//[HttpPost]
	//public async Task<ActionResult<int>> Rule(CreateRuleCommand command)
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
	//public async Task<ActionResult> Rule(UpdateRuleCommand command)
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
	//public async Task<ActionResult> Rule(int id)
	//{
	//	try
	//	{
	//		await Mediator.Send(new DeleteRuleCommand() { Id = id });
	//		return NoContent();
	//	}
	//	catch (Exception)
	//	{
	//		return ValidationProblem();
	//	}
	//}
}
