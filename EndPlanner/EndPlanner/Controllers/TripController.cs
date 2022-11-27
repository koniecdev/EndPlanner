using EndPlannerApp.Shared.Trips.Commands;
using EndPlannerApp.Shared.Trips.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EndPlanner.Controllers;

[Route("api/trips")]
public class TripController : BaseController
{
	[HttpGet]
	[Route("{id}")]
	public async Task<ActionResult<GetTripVm>> TripById(int id)
	{
		var response = await Mediator.Send(new GetTripQuery() { Id = id });
		return Ok(response);
	}
	[HttpPost]
	public async Task<ActionResult<int>> Trip(CreateTripCommand command)
	{
		try
		{
			return Ok(await Mediator.Send(command));
		}
		catch (Exception)
		{
			return ValidationProblem(detail: "There was a problem with creating entity, please try again");
		}
	}
	[HttpPatch]
	public async Task<ActionResult> Trip(UpdateTripCommand command)
	{
		try
		{
			await Mediator.Send(command);
			return NoContent();
		}
		catch (Exception)
		{
			return ValidationProblem(detail: "There was a problem with updating entity, please try again");
		}
	}
	[HttpDelete]
	public async Task<ActionResult> Trip(int id)
	{
		try
		{
			await Mediator.Send(new DeleteTripCommand() { Id = id });
			return NoContent();
		}
		catch (Exception)
		{
			return ValidationProblem(detail: "There was a problem with deleting entity, ensure provided id is valid");
		}
	}
}
