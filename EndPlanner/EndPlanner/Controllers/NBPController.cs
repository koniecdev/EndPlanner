using EndPlannerApp.Shared.NBP.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace EndPlanner.Controllers
{
	[Route("api/nbp-apis")]
	public class NBPController : BaseController
	{
		[HttpGet]
		[Route("eu")]
		public async Task<ActionResult<GetEuExchangesVm>> GetMemberTripsCarsVm()
		{
			var response = await Mediator.Send(new GetEuExchangesQuery());
			return response;
		}

	//[HttpPost]
	//public async Task<ActionResult<int>> Member(CreateMemberCommand command)
	//{
	//	int response = await Mediator.Send(command);
	//	return response;
	//}
}
}