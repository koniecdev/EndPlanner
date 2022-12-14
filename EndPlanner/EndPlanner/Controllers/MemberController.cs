using EndPlannerApp.Shared.Members.Commands;
using EndPlannerApp.Shared.Members.Queries;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPlanner.Controllers;

[Route("api/members")]
public class MemberController : BaseController
{
	[HttpGet]
	[Route("trips-cars/{userId}")]
	public async Task<ActionResult<GetMemberTripsCarsVm>> GetMemberTripsCarsVm(string userId)
	{
		var response = await Mediator.Send(new GetMemberTripsCarsQuery() { UserId = userId });
		return Ok(response);
	}

	[HttpPost]
	[AllowAnonymous]
	public async Task<ActionResult<int>> Member(CreateMemberCommand command)
	{
		var secret = Request.Headers["AuthEnd"].ToString();
		if ("secret".ToSha512() != secret)
		{
			return Conflict();
		}
		try
		{
			int response = await Mediator.Send(command);
			return Ok(response);
		}
		catch
		{
			return UnprocessableEntity();
		}
	}

	[HttpPatch]
	public async Task<ActionResult> Member(UpdateMemberCommand command)
	{
		try
		{
			await Mediator.Send(command);
			return NoContent();
		}
		catch
		{
			return UnprocessableEntity();
		}
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> Member(int id)
	{
		try
		{
			await Mediator.Send(new DeleteMemberCommand() { Id = id});
			return NoContent();
		}
		catch
		{
			return UnprocessableEntity();
		}
	}
}
