using Microsoft.AspNetCore.Mvc;

namespace EndPlanner.Controllers
{
	[Route("api/members")]
	public class MemberController : BaseController
	{
		//[HttpGet]
		//[Route("trips-cars/{userId}")]
		//public async Task<ActionResult<ICollection<GetMemberTripsCarsVm>>> GetMemberTripsCarsVm(int userId)
		//{
		//	var response = await Mediator.Send(new GetMemberTripsCarsQuery(){ UserId = userId; });
		//	return response;
		//}

		//[HttpPost]
		//public async Task<ActionResult<int>> Member(CreateMemberCommand command)
		//{
		//	int response = await Mediator.Send(command);
		//	return response;
		//}
	}
}